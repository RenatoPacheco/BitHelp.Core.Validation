﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class DoubleIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification DoubleIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.DoubleIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification DoubleIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.DoubleIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification DoubleIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.DoubleIsValid(data);
        }

        #endregion

        public static ValidationNotification DoubleIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.DoubleIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification DoubleIsValid(
            this ValidationNotification source, object value)
        {
            return source.DoubleIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification DoubleIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            DoubleIsValidAttribute validation = new DoubleIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
