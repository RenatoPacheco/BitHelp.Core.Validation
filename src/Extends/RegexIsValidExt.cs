﻿using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

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

        public static ValidationNotification RegexIsValid(
            this ValidationNotification source, IStructureToValidate data,
            string pattern, RegexOptions options = RegexOptions.None)
        {
            source.CleanLastMessage();
            RegexIsValidAttribute validation = new RegexIsValidAttribute(pattern, options);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
