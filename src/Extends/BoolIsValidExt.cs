using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BoolIsValidExt
    {
        public static ValidationNotification BoolIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BoolIsValid(value, display, reference);
        }

        public static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value)
        {
            return source.BoolIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            BoolIsValidAttribute validation = new BoolIsValidAttribute();
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
