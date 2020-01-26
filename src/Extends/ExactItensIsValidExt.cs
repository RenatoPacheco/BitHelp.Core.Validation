using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactItensIsValidExt
    {
        public static ValidationNotification ExactItensIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression, int exact)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.ExactItensIsValid(value, display, prorpety, exact);
        }

        public static ValidationNotification ExactItensIsValid(
            this ValidationNotification source, IList value, int exact)
        {
            return source.ExactItensIsValid(value, Resource.DisplayValue, null, exact);
        }

        private static ValidationNotification ExactItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            source.LastMessage = null;
            ExactItensIsValidAttribute validation = new ExactItensIsValidAttribute(exact);
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
