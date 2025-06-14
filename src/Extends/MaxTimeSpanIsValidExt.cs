﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MaxTimeSpanIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.MaxTimeSpanIsValid(
                source.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid<T>(
            this T source, object value, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.MaxTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid<T>(
            this T source, IStructureToValidate data, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.Notifications.MaxTimeSpanIsValid(data, maximum);
        }

        #endregion

        public static ValidationNotification MaxTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, TimeSpan maximum)
        {
            source.CleanLastMessage();
            MaxTimeSpanIsValidAttribute validation = new MaxTimeSpanIsValidAttribute(maximum);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
