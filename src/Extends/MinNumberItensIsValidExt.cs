using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinNumberItensIsValidExt
    {
        public static ValidationNotification MinNumberItensIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, IList>> expression, int minimum)
        {
            string prorpety = expression.PropertyTrail();
            IList value = expression.Compile().DynamicInvoke(data) as IList;
            string display = expression.PropertyDisplay();
            return source.MinNumberItensIsValid(value, display, prorpety, minimum);
        }

        public static ValidationNotification MinNumberItensIsValid(
            this ValidationNotification source, IList value, int minimum)
        {
            return source.MinNumberItensIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinNumberItensIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            source.LastMessage = null;
            MinNumberItensIsValidAttribute validation = new MinNumberItensIsValidAttribute(minimum);
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
