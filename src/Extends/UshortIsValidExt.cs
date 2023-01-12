using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class UshortIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification UshortIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.UshortIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification UshortIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.UshortIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UshortIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.UshortIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification UshortIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.UshortIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification UshortIsValid(
            this ValidationNotification source, object value)
        {
            return source.UshortIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UshortIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            UshortIsValidAttribute validation = new UshortIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }

        #endregion
    }
}
