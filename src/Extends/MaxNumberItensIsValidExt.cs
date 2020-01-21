using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxNumberItensIsValidExt
    {
        public static ValidationNotification MaxNumberItensIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, IList>> expression, int maximum)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MaxNumberItensIsValid(value, display, prorpety, maximum);
        }

        public static ValidationNotification MaxNumberItensIsValid(
            this ValidationNotification source, IList value, int maximum)
        {
            return source.MaxNumberItensIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxNumberItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            source.LastMessage = null;
            MaxNumberItensIsValidAttribute validation = new MaxNumberItensIsValidAttribute(maximum);
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
