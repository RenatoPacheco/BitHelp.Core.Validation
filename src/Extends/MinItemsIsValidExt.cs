using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MinItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression, int minimum)
            where T : ISelfValidation
        {
            return source.MinItemsIsValid(
                source.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinItemsIsValid<T>(
            this T source, IEnumerable value, int minimum)
            where T : ISelfValidation
        {
            return source.MinItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        public static ValidationNotification MinItemsIsValid<T>(
            this T source, IStructureToValidate data, int minimum)
            where T : ISelfValidation
        {
            return source.Notifications.MinItemsIsValid(data, minimum);
        }

        #endregion

        public static ValidationNotification MinItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression, int minimum)
        {
            return source.MinItemsIsValid(
                data.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, IEnumerable value, int minimum)
        {
            return source.MinItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        public static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum)
        {
            source.CleanLastMessage();
            MinItemsIsValidAttribute validation = new MinItemsIsValidAttribute(minimum);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
