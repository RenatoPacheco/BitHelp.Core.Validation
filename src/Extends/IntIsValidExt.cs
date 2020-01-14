using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class IntIsValidExt
    {
        public static ValidationNotification IntEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.IntEhValido(value, display, prorpety);
        }

        public static ValidationNotification IntEhValido(
            this ValidationNotification source, object value)
        {
            return source.IntEhValido(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification IntEhValido(
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
