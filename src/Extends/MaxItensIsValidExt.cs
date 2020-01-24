using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxItensIsValidExt
    {
        public static ValidationNotification MaxItensIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MaxItensIsValid(value, display, prorpety, maximum);
        }

        public static ValidationNotification MaxItensIsValid(
            this ValidationNotification source, IList value, int maximum)
        {
            return source.MaxItensIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            source.LastMessage = null;
            MaxItensIsValidAttribute validation = new MaxItensIsValidAttribute(maximum);
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
