﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxCharactersIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MaxCharactersIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, int maximum)
            where T : ISelfValidation
        {
            return source.MaxCharactersIsValid(
                source.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxCharactersIsValid<T>(
            this T source, object value, int maximum)
            where T : ISelfValidation
        {
            return source.MaxCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxCharactersIsValid<T>(
            this T source, IStructureToValidate data, int maximum)
            where T : ISelfValidation
        {
            return source.Notifications.MaxCharactersIsValid(data, maximum);
        }

        #endregion

        public static ValidationNotification MaxCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int maximum)
        {
            return source.MaxCharactersIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, object value, int maximum)
        {
            return source.MaxCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int maximum)
        {
            source.CleanLastMessage();
            MaxCharactersIsValidAttribute validation = new MaxCharactersIsValidAttribute(maximum);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }
    }
}
