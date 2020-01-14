using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DecimalIsValidExt
    {
        public static ValidationNotification DecimalEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.DecimalEhValido(value, display, prorpety);
        }

        public static ValidationNotification DecimalEhValido(
            this ValidationNotification source, object value)
        {
            return source.DecimalEhValido(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification DecimalEhValido(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            DecimalIsValidAttribute validation = new DecimalIsValidAttribute();
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
