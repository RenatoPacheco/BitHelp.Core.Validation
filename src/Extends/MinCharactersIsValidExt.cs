using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinCharactersIsValidExt
    {
        public static ValidationNotification MinCharactersIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int minimum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinCharactersIsValid(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinCharactersIsValid(
            this ValidationNotification source, object value, int minimum)
        {
            return source.MinCharactersIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            source.LastMessage = null;
            MinCharactersIsValidAttribute validation = new MinCharactersIsValidAttribute(minimum);
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
