using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeTimeSpanIsValidExt
    {
        public static ValidationNotification RangeTimeSpanIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, TimeSpan minimum, TimeSpan maximum)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RangeTimeSpanIsValid(value, display, reference, minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(value, Resource.DisplayValue, null, minimum, maximum);
        }

        private static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan minimum, TimeSpan maximum)
        {
            source.LastMessage = null;
            RangeTimeSpanIsValidAttribute validation = new RangeTimeSpanIsValidAttribute(minimum, maximum);
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
