﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class CpfIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification CpfIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.CpfIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification CpfIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.CpfIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification CpfIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.CpfIsValid(data);
        }

        #endregion

        public static ValidationNotification CpfIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.CpfIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification CpfIsValid(
            this ValidationNotification source, object value)
        {
            return source.CpfIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification CpfIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            CpfIsValidAttribute validation = new CpfIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
