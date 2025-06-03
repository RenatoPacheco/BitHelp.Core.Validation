using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenStringIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenStringIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<string> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(
                source.GetStructureToValidate(expression), options, deny);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source,
            object value, 
            IEnumerable<string> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenStringIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            IEnumerable<string> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenStringIsValid(data, options, deny);
        }

        #endregion

        public static ValidationNotification BetweenStringIsValid<T, P>(
            this ValidationNotification source, T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<string> options,
            bool deny = false)
        {
            return source.BetweenStringIsValid(
                data.GetStructureToValidate(expression),
                options, deny);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, 
            object value, 
            IEnumerable<string> options, 
            bool deny = false)
        {
            return source.BetweenStringIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenStringIsValid(
            this ValidationNotification source, 
            IStructureToValidate data,
            IEnumerable<string> options, 
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenStringIsValidAttribute validation = new BetweenStringIsValidAttribute(options, deny);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }
    }
}
