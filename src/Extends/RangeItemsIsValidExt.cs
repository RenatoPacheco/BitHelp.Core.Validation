using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeItemsIsValidExt
    {
        public static ValidationNotification RangeItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression, int minimum, int maximum)
        {
            string reference = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.RangeItemsIsValid(value, display, reference, minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, IList value, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(value, Resource.DisplayValue, null, minimum, maximum);
        }

        private static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeItemsIsValidAttribute validation = new RangeItemsIsValidAttribute(minimum, maximum);
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
