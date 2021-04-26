using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenTimeSpanIsValidExt
    {
        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<TimeSpan> options)
        {
            return source.BetweenTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source, object value, IEnumerable<TimeSpan> options)
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        [Obsolete("Use BetweenTimeSpanIsValid(IStructureToValidate data, IEnumerable<Enum> options)")]
        private static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<TimeSpan> options)
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, options);
        }

        private static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, IEnumerable<TimeSpan> options)
        {
            source.LastMessage = null;
            BetweenTimeSpanIsValidAttribute validation = new BetweenTimeSpanIsValidAttribute(options);
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
