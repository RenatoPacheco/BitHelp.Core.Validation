using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Utilities;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenShortIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<short> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenNumberIsValid(
                source.GetStructureToValidate(expression),
                options, deny);
        }

        public static ValidationNotification BetweenNumberIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<short> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenNumberIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            IEnumerable<short> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenNumberIsValid(data, options, deny);
        }

        #endregion

        #region To ValidationNotification

        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this ValidationNotification source, 
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<short> options,
            bool deny = false)
        {
            return source.BetweenNumberIsValid(
                data.GetStructureToValidate(expression),
                options, deny);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, 
            object value, 
            IEnumerable<short> options,
            bool deny = false)
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, 
            IStructureToValidate data, 
            IEnumerable<short> options,
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenNumberIsValidAttribute validation = new BetweenNumberIsValidAttribute(options, deny);
            if (!validation.IsValid(data.Value)) {
                source.RegisterError(data, validation);
            }
            return source;
        }

        #endregion
    }
}
