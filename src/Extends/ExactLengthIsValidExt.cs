using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactLengthIsValidExt
    {
        public static ValidationNotification ExactLengthIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int exact)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.ExactLengthIsValid(value, display, prorpety, exact);
        }

        public static ValidationNotification ExactLengthIsValid(
            this ValidationNotification source, object value, int exact)
        {
            return source.ExactLengthIsValid(value, Resource.DisplayValue, null, exact);
        }

        private static ValidationNotification ExactLengthIsValid(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            source.LastMessage = null;
            ExactLengthIsValidAttribute validation = new ExactLengthIsValidAttribute(exact);
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
