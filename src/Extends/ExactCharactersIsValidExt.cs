using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactCharactersIsValidExt
    {
        public static ValidationNotification ExactCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int exact)
        {
            return source.ExactCharactersIsValid(
                data.GetStructureToValidate(expression),
                exact);
        }

        public static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, object value, int exact)
        {
            return source.ExactCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, exact);
        }

        private static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            return source.ExactCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, exact);
        }

        private static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int exact)
        {
            source.LastMessage = null;
            ExactCharactersIsValidAttribute validation = new ExactCharactersIsValidAttribute(exact);
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
