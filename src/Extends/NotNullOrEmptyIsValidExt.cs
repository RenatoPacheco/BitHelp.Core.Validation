﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class NotNullOrEmptyIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification NotNullOrEmptyIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.NotNullOrEmptyIsValid(
                source.GetStructureToValidate(expression),
                ignoreWithSpace);
        }

        public static ValidationNotification NotNullOrEmptyIsValid<T>(
            this T source, object value,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.NotNullOrEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, ignoreWithSpace);
        }

        public static ValidationNotification NotNullOrEmptyIsValid<T>(
            this T source, IStructureToValidate data,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.Notifications.NotNullOrEmptyIsValid(data, ignoreWithSpace);
        }

        #endregion

        public static ValidationNotification NotNullOrEmptyIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, bool ignoreWithSpace = false)
        {
            return source.NotNullOrEmptyIsValid(
                data.GetStructureToValidate(expression),
                ignoreWithSpace);
        }

        public static ValidationNotification NotNullOrEmptyIsValid(
            this ValidationNotification source, object value, bool ignoreWithSpace = false)
        {
            return source.NotNullOrEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, ignoreWithSpace);
        }

        [Obsolete("Use NotNullOrEmptyIsValid(IStructureToValidate data, bool ignoreWithSpace)")]
        private static ValidationNotification NotNullOrEmptyIsValid(
            this ValidationNotification source, object value, string display, string reference, bool ignoreWithSpace)
        {
            return source.NotNullOrEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, ignoreWithSpace);
        }

        public static ValidationNotification NotNullOrEmptyIsValid(
            this ValidationNotification source, IStructureToValidate data, bool ignoreWithSpace)
        {
            source.LastMessage = null;
            NotNullOrEmptyIsValidAttribute validation = new NotNullOrEmptyIsValidAttribute(ignoreWithSpace);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
