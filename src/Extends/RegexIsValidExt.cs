using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RegexIsValidExt
    {
        public static ValidationNotification RegexEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, string pattern, RegexOptions options = RegexOptions.None)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.RegexEhValido(value, display, prorpety, pattern, options);
        }

        public static ValidationNotification RegexEhValido(
            this ValidationNotification source, object value, string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.RegexEhValido(value, Resource.DisplayValue, null, pattern, options);
        }

        private static ValidationNotification RegexEhValido(
            this ValidationNotification source, object value, string display, string reference, string pattern, RegexOptions options = RegexOptions.None)
        {
            source.LastMessage = null;
            RegexIsValidAttribute validation = new RegexIsValidAttribute(pattern, options);
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
