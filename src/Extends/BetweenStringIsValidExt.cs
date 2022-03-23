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
            this T source, Expression<Func<T, P>> expression, IEnumerable<string> options)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(
                source.GetStructureToValidate(expression), options);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source, object value, IEnumerable<string> options)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source, IStructureToValidate data, IEnumerable<string> options)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenStringIsValid(data, options);
        }

        #endregion

        public static ValidationNotification BetweenStringIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<string> options)
        {
            return source.BetweenStringIsValid(
                data.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, object value, IEnumerable<string> options)
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, IStructureToValidate data, IEnumerable<string> options)
        {
            source.CleanLastMessage();
            BetweenStringIsValidAttribute validation = new BetweenStringIsValidAttribute(options);
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
