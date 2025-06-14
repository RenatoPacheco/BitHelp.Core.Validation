﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class EmailIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification EmailIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.EmailIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification EmailIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.EmailIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification EmailIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.EmailIsValid(data);
        }

        #endregion

        public static ValidationNotification EmailIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.EmailIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification EmailIsValid(
            this ValidationNotification source, object value)
        {
            return source.EmailIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification EmailIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            EmailIsValidAttribute validation = new EmailIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
