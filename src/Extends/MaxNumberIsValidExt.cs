using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxNumberIsValidExt
    {
        public static ValidationNotification MaxNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal maximum)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MaxNumberIsValid(value, display, reference, maximum);
        }

        public static ValidationNotification MaxNumberIsValid(
            this ValidationNotification source, object value, decimal maximum)
        {
            return source.MaxNumberIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal maximum)
        {
            source.LastMessage = null;
            MaxNumberIsValidAttribute validation = new MaxNumberIsValidAttribute(maximum);
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
