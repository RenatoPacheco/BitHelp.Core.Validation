using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeCharactersIsValidExt
    {
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

        [Obsolete("Use RangeCharactersIsValid(IStructureToValidate data, int minimum, int maximum)")]
        private static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            return source.RangeCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum, maximum);
        }

        public static ValidationNotification RangeCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeCharactersIsValidAttribute validation = new RangeCharactersIsValidAttribute(minimum, maximum);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
