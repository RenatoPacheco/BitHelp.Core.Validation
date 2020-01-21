using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BoolIsValidExt
    {
        public static ValidationNotification BoolIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BoolIsValid(value, display, prorpety);
        }

        public static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value, string reference = null)
        {
            return source.BoolIsValid(value, Resource.DisplayValue, reference);
        }

        private static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            BoolIsValidAttribute validation = new BoolIsValidAttribute();
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
