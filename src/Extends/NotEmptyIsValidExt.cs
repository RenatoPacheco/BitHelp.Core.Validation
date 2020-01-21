using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class NotEmptyIsValidExt
    {
        public static ValidationNotification NotEmptyIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.NotEmptyIsValid(value, display, prorpety);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value)
        {
            return source.NotEmptyIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            NotEmptyIsValidAttribute validation = new NotEmptyIsValidAttribute();
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
