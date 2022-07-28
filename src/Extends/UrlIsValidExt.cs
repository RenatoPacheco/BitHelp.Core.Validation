using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class UrlIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification UrlIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.UrlIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification UrlIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.UrlIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UrlIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.UrlIsValid(data);
        }

        #endregion

        public static ValidationNotification UrlIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.UrlIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification UrlIsValid(
            this ValidationNotification source, object value)
        {
            return source.UrlIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification UrlIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            UrlIsValidAttribute validation = new UrlIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }
    }
}
