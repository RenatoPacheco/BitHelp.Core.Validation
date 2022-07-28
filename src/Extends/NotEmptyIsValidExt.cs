using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class NotEmptyIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification NotEmptyIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.NotEmptyIsValid(
                source.GetStructureToValidate(expression),
                ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid<T>(
            this T source, object value,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.NotEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid<T>(
            this T source, IStructureToValidate data,
            bool ignoreWithSpace = false)
            where T : ISelfValidation
        {
            return source.Notifications.NotEmptyIsValid(data, ignoreWithSpace);
        }

        #endregion

        public static ValidationNotification NotEmptyIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, bool ignoreWithSpace = false)
        {
            return source.NotEmptyIsValid(
                data.GetStructureToValidate(expression),
                ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, bool ignoreWithSpace = false)
        {
            return source.NotEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, IStructureToValidate data, bool ignoreWithSpace)
        {
            source.CleanLastMessage();
            NotEmptyIsValidAttribute validation = new NotEmptyIsValidAttribute(ignoreWithSpace);
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
