using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class DenyRegexIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification DenyRegexIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.DenyRegexIsValid(
                source.GetStructureToValidate(expression),
                pattern, options);
        }

        public static ValidationNotification DenyRegexIsValid<T>(
            this T source, object value,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.DenyRegexIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, pattern, options);
        }

        public static ValidationNotification DenyRegexIsValid<T>(
            this T source, IStructureToValidate data,
            string pattern, RegexOptions options = RegexOptions.None)
            where T : ISelfValidation
        {
            return source.Notifications.DenyRegexIsValid(
                data, pattern, options);
        }

        #endregion

        public static ValidationNotification DenyRegexIsValid<T, P>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.DenyRegexIsValid(
                data.GetStructureToValidate(expression),
                pattern, options);
        }

        public static ValidationNotification DenyRegexIsValid(
            this ValidationNotification source, object value,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.DenyRegexIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, pattern, options);
        }

        public static ValidationNotification DenyRegexIsValid(
            this ValidationNotification source, IStructureToValidate data,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            source.CleanLastMessage();
            DenyRegexIsValidAttribute validation = new DenyRegexIsValidAttribute(pattern, options);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
