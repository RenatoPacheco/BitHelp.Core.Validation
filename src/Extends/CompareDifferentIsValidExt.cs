using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareDifferentIsValidExt
    {
        public static ValidationNotification CompareDifferentIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
        {
            return source.CompareDifferentIsValid(
                data.GetStructureToValidate(expression),
                data.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification CompareDifferentIsValid(
            this ValidationNotification source,
            IStructureToValidate data,
            IStructureToValidate dataCompare)
        {
            string reference = data.Reference;

            object value = data.Value;
            string display = data.Display;

            object valueCompare = dataCompare.Value;
            string displayCompare = dataCompare.Display;

            source.LastMessage = null;

            if (!(value is null))
            {
                if (value?.ToString() == valueCompare?.ToString())
                {
                    string text = string.Format(
                        Resource.XCompareDifferentInvalid,
                        display, displayCompare);

                    var message = new ValidationMessage(text, reference);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }

            return source;
        }
    }
}
