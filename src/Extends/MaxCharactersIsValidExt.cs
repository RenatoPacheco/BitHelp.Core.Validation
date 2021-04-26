using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxCharactersIsValidExt
    {
        public static ValidationNotification MaxCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int maximum)
        {
            return source.MaxCharactersIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, object value, int maximum)
        {
            return source.MaxCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        [Obsolete("Use MaxCharactersIsValid(IStructureToValidate data, int maximum)")]
        private static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int maximum)
        {
            return source.MaxCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, maximum);
        }

        private static ValidationNotification MaxCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int maximum)
        {
            source.LastMessage = null;
            MaxCharactersIsValidAttribute validation = new MaxCharactersIsValidAttribute(maximum);
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
