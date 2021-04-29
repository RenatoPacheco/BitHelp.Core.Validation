using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinDateTimeIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification MinDateTimeIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            DateTime minimum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.MinDateTimeIsValid(
                source.GetStructureToValidate(expression),
                minimum, cultureInfo);
        }

        public static ValidationNotification MinDateTimeIsValid<T>(
            this T source, object value,
            DateTime minimum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.MinDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, cultureInfo);
        }

        public static ValidationNotification MinDateTimeIsValid<T>(
            this T source, IStructureToValidate data,
            DateTime minimum, CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.Notifications.MinDateTimeIsValid(data, minimum, cultureInfo);
        }

        #endregion

        public static ValidationNotification MinDateTimeIsValid<T, P>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            DateTime minimum, CultureInfo cultureInfo = null)
        {
            return source.MinDateTimeIsValid(
                data.GetStructureToValidate(expression),
                minimum, cultureInfo);
        }

        public static ValidationNotification MinDateTimeIsValid(
            this ValidationNotification source, object value,
            DateTime minimum, CultureInfo cultureInfo = null)
        {
            return source.MinDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, cultureInfo);
        }

        [Obsolete("Use MinDateTimeIsValid(IStructureToValidate data, DateTime minimum, CultureInfo cultureInfo = null)")]
        private static ValidationNotification MinDateTimeIsValid(
            this ValidationNotification source, object value,
            string display, string reference, DateTime minimum,
            CultureInfo cultureInfo = null)
        {
            return source.MinDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum);
        }

        public static ValidationNotification MinDateTimeIsValid(
            this ValidationNotification source, IStructureToValidate data,
            DateTime minimum, CultureInfo cultureInfo = null)
        {
            source.LastMessage = null;
            MinDateTimeIsValidAttribute validation = new MinDateTimeIsValidAttribute(minimum, cultureInfo);
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
