using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DecimalIsValidExt
    {
        public static ValidationNotification DecimalIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.DecimalIsValid(value, display, prorpety);
        }

        public static ValidationNotification DecimalIsValid(
            this ValidationNotification source, object value)
        {
            return source.DecimalIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification DecimalIsValid(
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
