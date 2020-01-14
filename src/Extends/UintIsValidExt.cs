using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class UintIsValidExt
    {
        public static ValidationNotification UintIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.UintIsValid(value, display, prorpety);
        }

        public static ValidationNotification UintIsValid(
            this ValidationNotification source, object value)
        {
            return source.UintIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification UintIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            UintIsValidAttribute validation = new UintIsValidAttribute();
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
