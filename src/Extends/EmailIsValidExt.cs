using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EmailIsValidExt
    {
        public static ValidationNotification EmailIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.EmailIsValid(value, display, reference);
        }

        public static ValidationNotification EmailIsValid(
            this ValidationNotification source, object value)
        {
            return source.EmailIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification EmailIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            EmailIsValidAttribute validation = new EmailIsValidAttribute();
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
