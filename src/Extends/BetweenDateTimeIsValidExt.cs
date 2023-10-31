using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenDateTimeIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenDateTimeIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression,
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenDateTimeIsValid(
                source.GetStructureToValidate(expression),
                options, cultureInfo, deny);
        }

        public static ValidationNotification BetweenDateTimeIsValid<T>(
            this T source, object value,
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.BetweenDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, cultureInfo, deny);
        }

        public static ValidationNotification BetweenDateTimeIsValid<T>(
            this T source,
            IStructureToValidate data,
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool deny = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenDateTimeIsValid(data,
                options, cultureInfo, deny);
        }

        #endregion

        public static ValidationNotification BetweenDateTimeIsValid<T, P>(
            this ValidationNotification source,
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<DateTime> options,
            CultureInfo cultureInfo = null,
            bool deny = false)
        {
            return source.BetweenDateTimeIsValid(
                data.GetStructureToValidate(expression),
                options, cultureInfo, deny);
        }

        public static ValidationNotification BetweenDateTimeIsValid(
            this ValidationNotification source, 
            object value,
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool deny = false)
        {
            return source.BetweenDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, cultureInfo, deny);
        }

        public static ValidationNotification BetweenDateTimeIsValid(
            this ValidationNotification source, 
            IStructureToValidate data,
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool deny = false)
        {
            source.CleanLastMessage();
            BetweenDateTimeIsValidAttribute validation = new BetweenDateTimeIsValidAttribute(options, cultureInfo, deny);
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
