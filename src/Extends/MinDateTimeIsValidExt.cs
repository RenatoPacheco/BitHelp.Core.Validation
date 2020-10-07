using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinDateTimeIsValidExt
    {
        public static ValidationNotification MinDateTimeIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, DateTime minimum, CultureInfo cultureInfo = null)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinDateTimeIsValid(value, display, reference, minimum, cultureInfo);
        }

        public static ValidationNotification MinDateTimeIsValid(
            this ValidationNotification source, object value, DateTime minimum, CultureInfo cultureInfo = null)
        {
            return source.MinDateTimeIsValid(value, Resource.DisplayValue, null, minimum, cultureInfo);
        }

        private static ValidationNotification MinDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, DateTime minimum, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            MinDateTimeIsValidAttribute validation = new MinDateTimeIsValidAttribute(minimum, cultureInfo);
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
