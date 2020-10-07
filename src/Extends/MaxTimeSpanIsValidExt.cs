using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxTimeSpanIsValidExt
    {
        public static ValidationNotification MaxTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan maximum)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MaxTimeSpanIsValid(value, display, reference, maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan maximum)
        {
            source.LastMessage = null;
            MaxTimeSpanIsValidAttribute validation = new MaxTimeSpanIsValidAttribute(maximum);
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
