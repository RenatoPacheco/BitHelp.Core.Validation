using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class LongIsValidExt
    {
        public static ValidationNotification LongIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.LongIsValid(value, display, reference);
        }

        public static ValidationNotification LongIsValid(
            this ValidationNotification source, object value)
        {
            return source.LongIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification LongIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            LongIsValidAttribute validation = new LongIsValidAttribute();
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
