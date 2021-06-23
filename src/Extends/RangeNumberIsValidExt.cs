using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeNumberIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RangeNumberIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            decimal minimum, decimal maximum)
            where T : ISelfValidation
        {
            return source.RangeNumberIsValid(
                source.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid<T>(
            this T source, object value,
            decimal minimum, decimal maximum)
            where T : ISelfValidation
        {
            return source.RangeNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid<T>(
            this T source, IStructureToValidate data,
            decimal minimum, decimal maximum)
            where T : ISelfValidation
        {
            return source.Notifications.RangeNumberIsValid(
                data, minimum, maximum);
        }

        #endregion

        public static ValidationNotification RangeNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        [Obsolete("Use RangeNumberIsValid(IStructureToValidate data, decimal minimum, decimal maximum)")]
        private static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, IStructureToValidate data, decimal minimum, decimal maximum)
        {
            source.CleanLastMessage();
            RangeNumberIsValidAttribute validation = new RangeNumberIsValidAttribute(minimum, maximum);
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
