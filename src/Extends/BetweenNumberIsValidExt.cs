using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenNumberIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<decimal> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenNumberIsValid(
                source.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenNumberIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<decimal> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenNumberIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            IEnumerable<decimal> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenNumberIsValid(data, options, denay);
        }

        #endregion

        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this ValidationNotification source, 
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<decimal> options,
            bool denay = false)
        {
            return source.BetweenNumberIsValid(
                data.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, 
            object value, 
            IEnumerable<decimal> options,
            bool denay = false)
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, 
            IStructureToValidate data, 
            IEnumerable<decimal> options,
            bool denay = false)
        {
            source.CleanLastMessage();
            BetweenNumberIsValidAttribute validation = new BetweenNumberIsValidAttribute(options, denay);
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
