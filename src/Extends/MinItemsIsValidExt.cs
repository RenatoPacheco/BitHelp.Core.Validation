using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinItemsIsValidExt
    {
        public static ValidationNotification MinItemsIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression, int minimum)
        {
            string reference = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MinItemsIsValid(value, display, reference, minimum);
        }

        public static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, IList value, int minimum)
        {
            return source.MinItemsIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            source.LastMessage = null;
            MinItemsIsValidAttribute validation = new MinItemsIsValidAttribute(minimum);
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
