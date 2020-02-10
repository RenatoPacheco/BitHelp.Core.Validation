using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class IntIsValidExt
    {
        public static ValidationNotification IntIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.IntIsValid(value, display, reference);
        }

        public static ValidationNotification IntIsValid(
            this ValidationNotification source, object value)
        {
            return source.IntIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification IntIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            IntIsValidAttribute validation = new IntIsValidAttribute();
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
