using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactCharactersIsValidExt
    {
        public static ValidationNotification ExactCharactersIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, int exact)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.ExactCharactersIsValid(value, display, prorpety, exact);
        }

        public static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, object value, int exact)
        {
            return source.ExactCharactersIsValid(value, Resource.DisplayValue, null, exact);
        }

        private static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            source.LastMessage = null;
            ExactCharactersIsValidAttribute validation = new ExactCharactersIsValidAttribute(exact);
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
