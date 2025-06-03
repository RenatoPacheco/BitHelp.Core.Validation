using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class LongIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification LongIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.LongIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification LongIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.LongIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification LongIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.LongIsValid(data);
        }

        #endregion

        public static ValidationNotification LongIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.LongIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification LongIsValid(
            this ValidationNotification source, object value)
        {
            return source.LongIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification LongIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            LongIsValidAttribute validation = new LongIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
