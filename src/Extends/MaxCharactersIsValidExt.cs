using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxCharactersIsValidExt
    {
        public static ValidationNotification MaxCharactersIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MaxCharactersIsValid(value, display, prorpety, maximum);
        }

        public static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, object value, int maximum)
        {
            return source.MaxCharactersIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            source.LastMessage = null;
            MaxCharactersIsValidAttribute validation = new MaxCharactersIsValidAttribute(maximum);
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
