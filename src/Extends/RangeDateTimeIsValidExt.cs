using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeDateTimeIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RangeDateTimeIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            DateTime minimum, DateTime maximum,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.RangeDateTimeIsValid(
                source.GetStructureToValidate(expression),
                minimum, maximum, cultureInfo);
        }

        public static ValidationNotification RangeDateTimeIsValid<T>(
            this T source, object value,
            DateTime minimum, DateTime maximum,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.RangeDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum, cultureInfo);
        }

        public static ValidationNotification RangeDateTimeIsValid<T>(
            this T source, IStructureToValidate data,
            DateTime minimum, DateTime maximum,
            CultureInfo cultureInfo = null)
            where T : ISelfValidation
        {
            return source.Notifications.RangeDateTimeIsValid(
                data, minimum, maximum, cultureInfo);
        }

        #endregion

        public static ValidationNotification RangeDateTimeIsValid<T, P>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            DateTime minimum, DateTime maximum,
            CultureInfo cultureInfo = null)
        {
            return source.RangeDateTimeIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum, cultureInfo);
        }

        public static ValidationNotification RangeDateTimeIsValid(
            this ValidationNotification source, object value,
            DateTime minimum, DateTime maximum,
            CultureInfo cultureInfo = null)
        {
            return source.RangeDateTimeIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum, cultureInfo);
        }

        public static ValidationNotification RangeDateTimeIsValid(
            this ValidationNotification source, IStructureToValidate data,
            DateTime minimum, DateTime maximum, CultureInfo cultureInfo = null)
        {
            source.CleanLastMessage();
            RangeDateTimeIsValidAttribute validation = new RangeDateTimeIsValidAttribute(minimum, maximum, cultureInfo);
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
