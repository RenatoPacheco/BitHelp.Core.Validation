using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class ShortIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification ShortIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.ShortIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification ShortIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.ShortIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification ShortIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.ShortIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification ShortIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.ShortIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification ShortIsValid(
            this ValidationNotification source, object value)
        {
            return source.ShortIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification ShortIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            ShortIsValidAttribute validation = new ShortIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
