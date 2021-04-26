using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessNumberIsValidExt
    {
        public static ValidationNotification CompareLessNumberIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
        {
            return source.CompareLessNumberIsValid(
                data.GetStructureToValidate(expression),
                data.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification CompareLessNumberIsValid(
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

            if (!(value is null) && !(valueCompare is null))
            {
                if (decimal.TryParse(Convert.ToString(value), out decimal newValue)
                    && decimal.TryParse(Convert.ToString(valueCompare), out decimal newCompare)
                    && newValue >= newCompare)
                {
                    string text = string.Format(
                        Resource.XCompareLessInvalid,
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
