using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeNumberIsValidExt
    {
        public static ValidationNotification RangeNumberIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int minimum, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RangeNumberIsValid(value, display, prorpety, minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, int minimum, int maximum)
        {
            return source.RangeNumberIsValid(value, Resource.DisplayValue, null, minimum, maximum);
        }

        private static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeNumberIsValidAttribute validation = new RangeNumberIsValidAttribute(minimum, maximum);
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
