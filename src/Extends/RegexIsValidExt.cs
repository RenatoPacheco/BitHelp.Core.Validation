using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RegexIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RegexIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.RegexIsValid(
                source.GetStructureToValidate(expression),
                pattern, options);
        }

        public static ValidationNotification RegexIsValid<T>(
            this T source, object value,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.RegexIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, pattern, options);
        }

        public static ValidationNotification RegexIsValid<T>(
            this T source, IStructureToValidate data,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.Notifications.RegexIsValid(
                data, pattern, options);
        }

        #endregion

        public static ValidationNotification RegexIsValid<T, P>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.RegexIsValid(
                data.GetStructureToValidate(expression),
                pattern, options);
        }

        public static ValidationNotification RegexIsValid(
            this ValidationNotification source, object value,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.RegexIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, pattern, options);
        }

        [Obsolete("Use RegexIsValid(IStructureToValidate data, string pattern, RegexOptions options = RegexOptions.None)")]
        private static ValidationNotification RegexIsValid(
            this ValidationNotification source, object value,
            string display, string reference,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.RegexIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, pattern, options);
        }

        public static ValidationNotification RegexIsValid(
            this ValidationNotification source, IStructureToValidate data,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            source.CleanLastMessage();
            RegexIsValidAttribute validation = new RegexIsValidAttribute(pattern, options);
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
