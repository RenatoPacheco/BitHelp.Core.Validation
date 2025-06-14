﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RangeTimeSpanIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            TimeSpan minimum, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.RangeTimeSpanIsValid(
                source.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid<T>(
            this T source, object value,
            TimeSpan minimum, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.RangeTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid<T>(
            this T source, IStructureToValidate data,
            TimeSpan minimum, TimeSpan maximum)
            where T : ISelfValidation
        {
            return source.Notifications.RangeTimeSpanIsValid(
                data, minimum, maximum);
        }

        #endregion

        public static ValidationNotification RangeTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, TimeSpan minimum, TimeSpan maximum)
        {
            source.CleanLastMessage();
            RangeTimeSpanIsValidAttribute validation = new RangeTimeSpanIsValidAttribute(minimum, maximum);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
