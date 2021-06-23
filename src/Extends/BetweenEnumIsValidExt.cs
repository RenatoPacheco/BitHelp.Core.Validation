using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenEnumIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, IEnumerable<Enum> options)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(
                source.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, object value, IEnumerable<Enum> options)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, IStructureToValidate data, IEnumerable<Enum> options)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenEnumIsValid(data, options);
        }

        #endregion

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(
                data.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        [Obsolete("Use BetweenEnumIsValid(IStructureToValidate data, IEnumerable<Enum> options)")]
        private static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, string display, string reference,
            IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, options);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, IStructureToValidate data, IEnumerable<Enum> options)
        {
            source.CleanLastMessage();
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(options);
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
