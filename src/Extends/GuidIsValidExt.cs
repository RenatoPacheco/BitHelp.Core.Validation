using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class GuidIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification GuidIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.GuidIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification GuidIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.GuidIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification GuidIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.GuidIsValid(data);
        }

        #endregion

        public static ValidationNotification GuidIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.GuidIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification GuidIsValid(
            this ValidationNotification source, object value)
        {
            return source.GuidIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification GuidIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            GuidIsValidAttribute validation = new GuidIsValidAttribute();
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
