using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class TimeSpanIsValidExt
    {
        public static ValidationNotification TimeSpanIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.TimeSpanIsValid(value, display, prorpety);
        }

        public static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value)
        {
            return source.TimeSpanIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            TimeSpanIsValidAttribute validation = new TimeSpanIsValidAttribute();
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
