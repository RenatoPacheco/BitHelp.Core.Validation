using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinNumberIsValidExt
    {
        public static ValidationNotification MinNumberIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, long minimum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinNumberIsValid(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, long minimum)
        {
            return source.MinNumberIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, long minimum)
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
