using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class UlongIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification UlongIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.UlongIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification UlongIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.UlongIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UlongIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.UlongIsValid(data);
        }

        #endregion

        public static ValidationNotification UlongIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.UlongIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification UlongIsValid(
            this ValidationNotification source, object value)
        {
            return source.UlongIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UlongIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            UlongIsValidAttribute validation = new UlongIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
