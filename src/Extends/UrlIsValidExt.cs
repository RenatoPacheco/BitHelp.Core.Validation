using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class UrlIsValidExt
    {
        public static ValidationNotification UrlEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data);
            string display = expression.PropertyDisplay();
            return source.UrlEhValido(value, display, prorpety);
        }

        public static ValidationNotification UrlEhValido(
            this ValidationNotification source, object value)
        {
            return source.UrlEhValido(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification UrlEhValido(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            UrlIsValidAttribute validation = new UrlIsValidAttribute();
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
