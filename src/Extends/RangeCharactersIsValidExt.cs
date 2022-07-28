using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeCharactersIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RangeCharactersIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.RangeCharactersIsValid(
                source.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid<T>(
            this T source, object value,
            int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.RangeCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid<T>(
            this T source, IStructureToValidate data,
            int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.Notifications.RangeCharactersIsValid(
                data, minimum, maximum);
        }

        #endregion

        public static ValidationNotification RangeCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int minimum, int maximum)
        {
            return source.RangeCharactersIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, object value, int minimum, int maximum)
        {
            return source.RangeCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum, int maximum)
        {
            source.CleanLastMessage();
            RangeCharactersIsValidAttribute validation = new RangeCharactersIsValidAttribute(minimum, maximum);
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
