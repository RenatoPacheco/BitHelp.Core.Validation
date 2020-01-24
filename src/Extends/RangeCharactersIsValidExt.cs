using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeCharactersIsValidExt
    {
        public static ValidationNotification RangeCharactersIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, int minimum, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RangeCharactersIsValid(value, display, prorpety, minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, object value, int minimum, int maximum)
        {
            return source.RangeCharactersIsValid(value, Resource.DisplayValue, null, minimum, maximum);
        }

        private static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeCharactersIsValidAttribute validation = new RangeCharactersIsValidAttribute(minimum, maximum);
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
