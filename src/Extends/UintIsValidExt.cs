using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class UintIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification UintIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.UintIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification UintIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.UintIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UintIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.UintIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification UintIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.UintIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification UintIsValid(
            this ValidationNotification source, object value)
        {
            return source.UintIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UintIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            UintIsValidAttribute validation = new UintIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
