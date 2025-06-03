using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenTimeSpanIsValid(
                source.GetStructureToValidate(expression), options, deny);
        }

        public static ValidationNotification BetweenTimeSpanIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenTimeSpanIsValid<T>(
            this T source,
            IStructureToValidate data, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenTimeSpanIsValid(data, options, deny);
        }

        #endregion

        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this ValidationNotification source, 
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
        {
            return source.BetweenTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                options, deny);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source,
            object value, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source,
            IStructureToValidate data, 
            IEnumerable<TimeSpan> options,
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenTimeSpanIsValidAttribute validation = new BetweenTimeSpanIsValidAttribute(options, deny);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
