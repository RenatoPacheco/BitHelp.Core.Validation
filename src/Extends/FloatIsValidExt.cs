using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class FloatIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification FloatIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.FloatIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification FloatIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.FloatIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification FloatIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.FloatIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification FloatIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.FloatIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification FloatIsValid(
            this ValidationNotification source, object value)
        {
            return source.FloatIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification FloatIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            FloatIsValidAttribute validation = new FloatIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
