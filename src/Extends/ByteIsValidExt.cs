using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class ByteIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification ByteIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.ByteIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification ByteIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.ByteIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification ByteIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.ByteIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification ByteIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.ByteIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification ByteIsValid(
            this ValidationNotification source, object value)
        {
            return source.ByteIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification ByteIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            ByteIsValidAttribute validation = new ByteIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
