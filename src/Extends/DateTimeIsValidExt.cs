using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DateTimeIsValidExt
    {
        public static ValidationNotification DateTimeIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, CultureInfo cultureInfo = null)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.DateTimeIsValid(value, display, prorpety, cultureInfo);
        }

        public static ValidationNotification DateTimeIsValid(
            this ValidationNotification source, object value, CultureInfo cultureInfo = null)
        {
            return source.DateTimeIsValid(value, Resource.DisplayValue, null, cultureInfo);
        }

        private static ValidationNotification DateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            DateTimeIsValidAttribute validation = new DateTimeIsValidAttribute() 
            { 
                CultureInfo = cultureInfo 
            };
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
