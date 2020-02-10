using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class SingletonItemsIsValidExt
    {
        public static ValidationNotification SingletonItemsIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.SingletonItemsIsValid(value, display, reference);
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, object value)
        {
            return source.SingletonItemsIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            SingletonItemsIsValidAttribute validation = new SingletonItemsIsValidAttribute();
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
