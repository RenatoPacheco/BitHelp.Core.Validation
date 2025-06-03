using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class SbyteIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification SbyteIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.SbyteIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification SbyteIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.SbyteIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification SbyteIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.SbyteIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification SbyteIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.SbyteIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification SbyteIsValid(
            this ValidationNotification source, object value)
        {
            return source.SbyteIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification SbyteIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            SbyteIsValidAttribute validation = new SbyteIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
