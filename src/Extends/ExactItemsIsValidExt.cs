using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactItemsIsValidExt
    {
        public static ValidationNotification ExactItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression, int exact)
        {
            string reference = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.ExactItemsIsValid(value, display, reference, exact);
        }

        public static ValidationNotification ExactItemsIsValid(
            this ValidationNotification source, IList value, int exact)
        {
            return source.ExactItemsIsValid(value, Resource.DisplayValue, null, exact);
        }

        private static ValidationNotification ExactItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            source.LastMessage = null;
            ExactItemsIsValidAttribute validation = new ExactItemsIsValidAttribute(exact);
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
