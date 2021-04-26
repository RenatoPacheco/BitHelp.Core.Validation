using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class SingletonItemsIsValidExt
    {
        public static ValidationNotification SingletonItemsIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.SingletonItemsIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, object value)
        {
            return source.SingletonItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use SingletonItemsIsValid(IStructureToValidate data)")]
        private static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.SingletonItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            SingletonItemsIsValidAttribute validation = new SingletonItemsIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
