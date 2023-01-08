using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenStringIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenStringIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<string> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(
                source.GetStructureToValidate(expression), options, denay);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source,
            object value, 
            IEnumerable<string> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            IEnumerable<string> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenStringIsValid(data, options, denay);
        }

        #endregion

        public static ValidationNotification BetweenStringIsValid<T, P>(
            this ValidationNotification source, T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<string> options,
            bool denay = false)
        {
            return source.BetweenStringIsValid(
                data.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, 
            object value, 
            IEnumerable<string> options, 
            bool denay = false)
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, 
            IStructureToValidate data,
            IEnumerable<string> options, 
            bool denay = false)
        {
            source.CleanLastMessage();
            BetweenStringIsValidAttribute validation = new BetweenStringIsValidAttribute(options, denay);
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
