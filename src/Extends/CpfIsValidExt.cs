using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CpfIsValidExt
    {
        public static ValidationNotification CpfIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.CpfIsValid(value, display, reference);
        }

        public static ValidationNotification CpfIsValid(
            this ValidationNotification source, object value)
        {
            return source.CpfIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification CpfIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            CpfIsValidAttribute validation = new CpfIsValidAttribute();
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
