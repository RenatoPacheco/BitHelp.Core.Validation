using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinCharactersIsValidExt
    {
        public static ValidationNotification MinCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int minimum)
        {
            return source.MinCharactersIsValid(
                data.GetStructureToValidate(expression),
                minimum);
        }

        public static ValidationNotification MinCharactersIsValid(
            this ValidationNotification source, object value, int minimum)
        {
            return source.MinCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum);
        }

        [Obsolete("Use MinCharactersIsValid(IStructureToValidate data, int minimum)")]
        private static ValidationNotification MinCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum)
        {
            return source.MinCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum);
        }

        public static ValidationNotification MinCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum)
        {
            source.LastMessage = null;
            MinCharactersIsValidAttribute validation = new MinCharactersIsValidAttribute(minimum);
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
