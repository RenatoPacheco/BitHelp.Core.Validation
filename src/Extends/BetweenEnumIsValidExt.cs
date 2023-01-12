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
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(
                source.GetStructureToValidate(expression),
                type, options, ignoreCase, denay);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            object value, 
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, options, ignoreCase, denay);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            IStructureToValidate data,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenEnumIsValid(
                data, type, options, ignoreCase, denay);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this ValidationNotification source, T data, 
            Expression<Func<T, P>> expression, 
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool denay = false)
        {
            return source.BetweenEnumIsValid(
                data.GetStructureToValidate(expression),
                type, options, ignoreCase, denay);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            object value,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool denay = false)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, options, ignoreCase, denay);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            IStructureToValidate data,
            Type type,
            IEnumerable<Enum> options,
            bool ignoreCase = false,
            bool denay = false)
        {
            source.CleanLastMessage();
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(type, options, ignoreCase, denay);
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
