﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MinTimeSpanIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, TimeSpan minimum)
            where T : ISelfValidation
        {
            return source.MinTimeSpanIsValid(
                source.GetStructureToValidate(expression), minimum);
        }

        public static ValidationNotification MinTimeSpanIsValid<T>(
            this T source, object value, TimeSpan minimum)
            where T : ISelfValidation
        {
            return source.MinTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        public static ValidationNotification MinTimeSpanIsValid<T>(
            this T source, IStructureToValidate data, TimeSpan minimum)
            where T : ISelfValidation
        {
            return source.Notifications.MinTimeSpanIsValid(data, minimum);
        }

        #endregion

        public static ValidationNotification MinTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan minimum)
        {
            return source.MinTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan minimum)
        {
            return source.MinTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        public static ValidationNotification MinTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, TimeSpan minimum)
        {
            source.CleanLastMessage();
            MinTimeSpanIsValidAttribute validation = new MinTimeSpanIsValidAttribute(minimum);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
