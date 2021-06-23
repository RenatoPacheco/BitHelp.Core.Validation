﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class IntIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification IntIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.IntIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification IntIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.IntIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification IntIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.IntIsValid(data);
        }

        #endregion

        public static ValidationNotification IntIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.IntIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification IntIsValid(
            this ValidationNotification source, object value)
        {
            return source.IntIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use IntIsValid(IStructureToValidate data)")]
        private static ValidationNotification IntIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.IntIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification IntIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            IntIsValidAttribute validation = new IntIsValidAttribute();
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
