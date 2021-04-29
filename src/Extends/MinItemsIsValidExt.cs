using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MinItemsIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, int minimum)
            where T : ISelfValidation
        {
            return source.MinItemsIsValid(
                source.GetStructureToValidate(expression), minimum);
        }

        public static ValidationNotification MinItemsIsValid<T>(
            this T source, object value, int minimum)
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
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression, int minimum)
        {
            return source.MinItemsIsValid(
                data.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, IList value, int minimum)
        {
            return source.MinItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        [Obsolete("Use MinItemsIsValid(IStructureToValidate data, int minimum)")]
        private static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            return source.MinItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum);
        }

        public static ValidationNotification MinItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum)
        {
            source.LastMessage = null;
            MinItemsIsValidAttribute validation = new MinItemsIsValidAttribute(minimum);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
