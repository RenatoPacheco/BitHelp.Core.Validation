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

        [Obsolete("Use MaxCharactersIsValid(IStructureToValidate data, DateTime maximum, CultureInfo cultureInfo)")]
        private static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, DateTime maximum, CultureInfo cultureInfo)
        {
            return source.MaxDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, maximum, cultureInfo);

        }

        private static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, IStructureToValidate data, DateTime maximum, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            MaxDateTimeIsValidAttribute validation = new MaxDateTimeIsValidAttribute(maximum, cultureInfo);
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
