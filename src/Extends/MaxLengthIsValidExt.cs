using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxLengthIsValidExt
    {
        public static ValidationNotification MaxLengthEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data);
            string display = expression.PropertyDisplay();
            return source.MaxLengthEhValido(value, display, prorpety, maximum);
        }

        public static ValidationNotification MaxLengthEhValido(
            this ValidationNotification source, object value, int maximum)
        {
            return source.MaxLengthEhValido(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxLengthEhValido(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            source.LastMessage = null;
            MaxLengthIsValidAttribute validation = new MaxLengthIsValidAttribute(maximum);
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
