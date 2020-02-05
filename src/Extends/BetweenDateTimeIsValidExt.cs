using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenDateTimeIsValidExt
    {
        public static ValidationNotification BetweenDateTimeIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, IEnumerable<DateTime> options, CultureInfo cultureInfo = null)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BetweenDateTimeIsValid(value, display, prorpety, options, cultureInfo);
        }

        public static ValidationNotification BetweenDateTimeIsValid(
            this ValidationNotification source, object value, IEnumerable<DateTime> options, CultureInfo cultureInfo = null)
        {
            return source.BetweenDateTimeIsValid(value, Resource.DisplayValue, null, options, cultureInfo);
        }

        private static ValidationNotification BetweenDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<DateTime> options, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            BetweenDateTimeIsValidAttribute validation = new BetweenDateTimeIsValidAttribute(options, cultureInfo);
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
