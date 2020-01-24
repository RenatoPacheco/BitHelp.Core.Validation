using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinItensIsValidExt
    {
        public static ValidationNotification MinItensIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression, int minimum)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MinItensIsValid(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinItensIsValid(
            this ValidationNotification source, IList value, int minimum)
        {
            return source.MinItensIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            source.LastMessage = null;
            MinItensIsValidAttribute validation = new MinItensIsValidAttribute(minimum);
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
