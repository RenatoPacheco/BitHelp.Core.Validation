using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinNumberIsValidExt
    {
        public static ValidationNotification MinNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal minimum)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinNumberIsValid(value, display, reference, minimum);
        }

        public static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, decimal minimum)
        {
            return source.MinNumberIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal minimum)
        {
            source.LastMessage = null;
            MinNumberIsValidAttribute validation = new MinNumberIsValidAttribute(minimum);
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
