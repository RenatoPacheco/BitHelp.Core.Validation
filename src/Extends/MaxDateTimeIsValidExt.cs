using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxDateTimeIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MaxDateTimeIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            DateTime maximum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.MaxDateTimeIsValid(
                source.GetStructureToValidate(expression),
                maximum, cultureInfo);
        }

        public static ValidationNotification MaxDateTimeIsValid<T>(
            this T source, object value,
            DateTime maximum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.MaxDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum, cultureInfo);
        }

        public static ValidationNotification MaxDateTimeIsValid<T>(
            this T source, IStructureToValidate data,
            DateTime maximum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.Notifications.MaxDateTimeIsValid(data, maximum, cultureInfo);
        }

        #endregion

        public static ValidationNotification MaxDateTimeIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, DateTime maximum, CultureInfo cultureInfo = null)
        {
            return source.MaxDateTimeIsValid(
                data.GetStructureToValidate(expression),
                maximum, cultureInfo);
        }

        public static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, object value, DateTime maximum, CultureInfo cultureInfo = null)
        {
            return source.MaxDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum, cultureInfo);
        }

        [Obsolete("Use MaxDateTimeIsValid(IStructureToValidate data, DateTime maximum, CultureInfo cultureInfo = null)")]
        private static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, DateTime maximum, CultureInfo cultureInfo = null)
        {
            return source.MaxDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, maximum, cultureInfo);

        }

        public static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, IStructureToValidate data, DateTime maximum, CultureInfo cultureInfo = null)
        {
            source.CleanLastMessage();
            MaxDateTimeIsValidAttribute validation = new MaxDateTimeIsValidAttribute(maximum, cultureInfo);
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
