﻿using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DateTimeIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification DateTimeIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.DateTimeIsValid(
                source.GetStructureToValidate(expression),
                cultureInfo);
        }

        public static ValidationNotification DateTimeIsValid<T>(
            this T source, object value,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.DateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, cultureInfo);
        }

        public static ValidationNotification DateTimeIsValid<T>(
            this T source, IStructureToValidate data,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.Notifications.DateTimeIsValid(data, cultureInfo);
        }

        #endregion

        public static ValidationNotification DateTimeIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, CultureInfo cultureInfo = null)
        {
            return source.DateTimeIsValid(
                data.GetStructureToValidate(expression),
                cultureInfo);
        }

        public static ValidationNotification DateTimeIsValid(
            this ValidationNotification source, object value, CultureInfo cultureInfo = null)
        {
            return source.DateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, cultureInfo);
        }

        [Obsolete("Use DateTimeIsValid(IStructureToValidate data, CultureInfo cultureInfo = null)")]
        private static ValidationNotification DateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, CultureInfo cultureInfo = null)
        {
            return source.DateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, cultureInfo);

        }

        public static ValidationNotification DateTimeIsValid(
            this ValidationNotification source, IStructureToValidate data, CultureInfo cultureInfo = null)
        {
            source.CleanLastMessage();
            DateTimeIsValidAttribute validation = new DateTimeIsValidAttribute(cultureInfo);
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
