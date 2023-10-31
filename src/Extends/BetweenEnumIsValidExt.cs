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
            this T source, 
            Expression<Func<T, P>> expression,
            Type type, 
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(
                source.GetStructureToValidate(expression),
                type, options, ignoreCase, deny);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            object value, 
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, options, ignoreCase, deny);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            IStructureToValidate data,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenEnumIsValid(
                data, type, options, ignoreCase, deny);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this ValidationNotification source, T data, 
            Expression<Func<T, P>> expression, 
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
        {
            return source.BetweenEnumIsValid(
                data.GetStructureToValidate(expression),
                type, options, ignoreCase, deny);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            object value,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, options, ignoreCase, deny);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            IStructureToValidate data,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(type, options, ignoreCase, deny);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }

        #endregion ValidationNotification
    }
}
