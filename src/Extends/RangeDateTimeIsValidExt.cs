using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeDateTimeIsValidExt
    {
        public static ValidationNotification RangeDateTimeIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, DateTime minimum, DateTime maximum, CultureInfo cultureInfo = null)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RangeDateTimeIsValid(value, display, prorpety, minimum, maximum, cultureInfo);
        }

        public static ValidationNotification RangeDateTimeIsValid(
            this ValidationNotification source, object value, DateTime minimum, DateTime maximum, CultureInfo cultureInfo = null)
        {
            return source.RangeDateTimeIsValid(value, Resource.DisplayValue, null, minimum, maximum, cultureInfo);
        }

        private static ValidationNotification RangeDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, DateTime minimum, DateTime maximum, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            RangeDateTimeIsValidAttribute validation = new RangeDateTimeIsValidAttribute(minimum, maximum, cultureInfo);
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
