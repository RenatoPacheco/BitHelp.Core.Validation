using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxItemsIsValidExt
    {
        public static ValidationNotification MaxItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression, int maximum)
        {
            string reference = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MaxItemsIsValid(value, display, reference, maximum);
        }

        public static ValidationNotification MaxItemsIsValid(
            this ValidationNotification source, IList value, int maximum)
        {
            return source.MaxItemsIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            source.LastMessage = null;
            MaxItemsIsValidAttribute validation = new MaxItemsIsValidAttribute(maximum);
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
