using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeItensIsValidExt
    {
        public static ValidationNotification RangeItensIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression, int minimum, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.RangeItensIsValid(value, display, prorpety, minimum, maximum);
        }

        public static ValidationNotification RangeItensIsValid(
            this ValidationNotification source, IList value, int minimum, int maximum)
        {
            return source.RangeItensIsValid(value, Resource.DisplayValue, null, minimum, maximum);
        }

        private static ValidationNotification RangeItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeItensIsValidAttribute validation = new RangeItensIsValidAttribute(minimum, maximum);
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
