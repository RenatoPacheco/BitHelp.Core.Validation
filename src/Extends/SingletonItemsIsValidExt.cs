using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class SingletonItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification SingletonItemsIsValid<T>(
            this T source, Expression<Func<T, IList>> expression)
            where T : ISelfValidation
        {
            return source.SingletonItemsIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification SingletonItemsIsValid<T>(
            this T source, IList value)
            where T : ISelfValidation
        {
            return source.SingletonItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification SingletonItemsIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.SingletonItemsIsValid(data);
        }

        #endregion

        public static ValidationNotification SingletonItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression)
        {
            return source.SingletonItemsIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, IList value)
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
