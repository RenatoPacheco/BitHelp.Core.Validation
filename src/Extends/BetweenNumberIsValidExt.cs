using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenNumberIsValidExt
    {
        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<decimal> options)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BetweenNumberIsValid(value, display, reference, options);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, object value, IEnumerable<decimal> options)
        {
            return source.BetweenNumberIsValid(value, Resource.DisplayValue, null, options);
        }

        private static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<decimal> options)
        {
            source.LastMessage = null;
            BetweenNumberIsValidAttribute validation = new BetweenNumberIsValidAttribute(options);
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
