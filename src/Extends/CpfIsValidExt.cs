using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CpfIsValidExt
    {
        public static ValidationNotification CpfEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.CpfEhValido(value, display, prorpety);
        }

        public static ValidationNotification CpfEhValido(
            this ValidationNotification source, object value)
        {
            return source.CpfEhValido(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification CpfEhValido(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            CpfIsValidAttribute validation = new CpfIsValidAttribute();
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
