using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenGuidIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenGuidIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<Guid> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenGuidIsValid(
                source.GetStructureToValidate(expression), options, deny);
        }

        public static ValidationNotification BetweenGuidIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<Guid> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenGuidIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenGuidIsValid<T>(
            this T source,
            IStructureToValidate data, 
            IEnumerable<Guid> options,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenGuidIsValid(data, options, deny);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification BetweenGuidIsValid<T, P>(
            this ValidationNotification source, 
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<Guid> options,
            bool deny = false)
        {
            return source.BetweenGuidIsValid(
                data.GetStructureToValidate(expression),
                options, deny);
        }

        public static ValidationNotification BetweenGuidIsValid(
            this ValidationNotification source,
            object value, 
            IEnumerable<Guid> options,
            bool deny = false)
        {
            return source.BetweenGuidIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, deny);
        }

        public static ValidationNotification BetweenGuidIsValid(
            this ValidationNotification source,
            IStructureToValidate data, 
            IEnumerable<Guid> options,
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenGuidIsValidAttribute validation = new BetweenGuidIsValidAttribute(options, deny);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }

        #endregion
    }
}
