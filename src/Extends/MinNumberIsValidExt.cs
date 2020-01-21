using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinNumberIsValidExt
    {
        public static ValidationNotification MinNumberIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int minimum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinNumberIsValid(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, int minimum)
        {
            return source.MinNumberIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
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
