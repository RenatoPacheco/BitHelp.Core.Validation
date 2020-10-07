using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenTimeSpanIsValidExt
    {
        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<TimeSpan> options)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BetweenTimeSpanIsValid(value, display, reference, options);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source, object value, IEnumerable<TimeSpan> options)
        {
            return source.BetweenTimeSpanIsValid(value, Resource.DisplayValue, null, options);
        }

        private static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<TimeSpan> options)
        {
            source.LastMessage = null;
            BetweenTimeSpanIsValidAttribute validation = new BetweenTimeSpanIsValidAttribute(options);
            if (!validation.IsValid(value))
            {
                string text = validation.FormatErrorMessage(display);
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
