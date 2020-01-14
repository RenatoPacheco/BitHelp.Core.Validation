using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinLengthIsValidExt
    {
        public static ValidationNotification MinLengthEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int minimum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.MinLengthEhValido(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinLengthEhValido(
            this ValidationNotification source, object value, int minimum)
        {
            return source.MinLengthEhValido(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinLengthEhValido(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            source.LastMessage = null;
            MinLengthIsValidAttribute validation = new MinLengthIsValidAttribute(minimum);
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
