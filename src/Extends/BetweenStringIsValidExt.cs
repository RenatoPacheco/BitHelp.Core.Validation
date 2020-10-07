using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenStringIsValidExt
    {
        public static ValidationNotification BetweenStringIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<string> options)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.BetweenStringIsValid(value, display, reference, options);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, object value, IEnumerable<string> options)
        {
            return source.BetweenStringIsValid(value, Resource.DisplayValue, null, options);
        }

        private static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<string> options)
        {
            source.LastMessage = null;
            BetweenStringIsValidAttribute validation = new BetweenStringIsValidAttribute(options);
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
