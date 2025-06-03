using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class SingletonItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification SingletonItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression)
            where T : ISelfValidation
        {
            return source.SingletonItemsIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification SingletonItemsIsValid<T>(
            this T source, IEnumerable value)
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
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression)
        {
            return source.SingletonItemsIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, IEnumerable value)
        {
            return source.SingletonItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification SingletonItemsIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            SingletonItemsIsValidAttribute validation = new SingletonItemsIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
