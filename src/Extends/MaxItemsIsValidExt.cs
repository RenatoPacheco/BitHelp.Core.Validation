using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MaxItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression, int maximum)
            where T : ISelfValidation
        {
            return source.MaxItemsIsValid(
                source.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxItemsIsValid<T>(
            this T source, IEnumerable value, int maximum)
            where T : ISelfValidation
        {
            return source.MaxItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxItemsIsValid<T>(
            this T source, IStructureToValidate data, int maximum)
            where T : ISelfValidation
        {
            return source.Notifications.MaxItemsIsValid(data, maximum);
        }

        #endregion

        public static ValidationNotification MaxItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression, int maximum)
        {
            return source.MaxItemsIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxItemsIsValid(
            this ValidationNotification source, IEnumerable value, int maximum)
        {
            return source.MaxItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        public static ValidationNotification MaxItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int maximum)
        {
            source.CleanLastMessage();
            MaxItemsIsValidAttribute validation = new MaxItemsIsValidAttribute(maximum);
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
