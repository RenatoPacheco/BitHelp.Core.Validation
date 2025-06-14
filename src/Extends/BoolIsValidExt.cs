﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class BoolIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BoolIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.BoolIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification BoolIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.BoolIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification BoolIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.BoolIsValid(data);
        }

        #endregion

        public static ValidationNotification BoolIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.BoolIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value)
        {
            return source.BoolIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification BoolIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            BoolIsValidAttribute validation = new BoolIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
