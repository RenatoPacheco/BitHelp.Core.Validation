using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenEnumIsValidExt
    {
        public static ValidationNotification BetweenEnumIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, IEnumerable<Enum> options)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BetweenEnumIsValid(value, display, prorpety, options);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(value, Resource.DisplayValue, null, options);
        }

        private static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<Enum> options)
        {
            source.LastMessage = null;
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(options);
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
