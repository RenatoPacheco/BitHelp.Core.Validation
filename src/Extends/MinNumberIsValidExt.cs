using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinNumberIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MinNumberIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, decimal minimum)
            where T : ISelfValidation
        {
            return source.MinNumberIsValid(
                source.GetStructureToValidate(expression), minimum);
        }

        public static ValidationNotification MinNumberIsValid<T>(
            this T source, object value, decimal minimum)
            where T : ISelfValidation
        {
            return source.MinNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        public static ValidationNotification MinNumberIsValid<T>(
            this T source, IStructureToValidate data, decimal minimum)
            where T : ISelfValidation
        {
            return source.Notifications.MinNumberIsValid(data, minimum);
        }

        #endregion

        public static ValidationNotification MinNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal minimum)
        {
            return source.MinNumberIsValid(
                data.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, decimal minimum)
        {
            return source.MinNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        [Obsolete("Use MinNumberIsValid(IStructureToValidate data, decimal minimum)")]
        private static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal minimum)
        {
            return source.MinNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum);
        }

        public static ValidationNotification MinNumberIsValid(
            this ValidationNotification source, IStructureToValidate data, decimal minimum)
        {
            source.CleanLastMessage();
            MinNumberIsValidAttribute validation = new MinNumberIsValidAttribute(minimum);
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
