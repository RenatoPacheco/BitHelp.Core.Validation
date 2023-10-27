using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessNumberIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification CompareLessNumberIsValid<T, P, PCompare>(
            this T source, Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
            where T : ISelfValidation
        {
            return source.CompareLessNumberIsValid(
                source.GetStructureToValidate(expression),
                source.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification CompareLessNumberIsValid<T>(
            this T source, IStructureToValidate data,
            IStructureToValidate dataCompare)
            where T : ISelfValidation
        {
            return source.Notifications.CompareLessNumberIsValid(data, dataCompare);
        }

        #endregion

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

            source.CleanLastMessage();

            if (!(value is null) && !(valueCompare is null)
                && decimal.TryParse(Convert.ToString(value), out decimal newValue)
                && decimal.TryParse(Convert.ToString(valueCompare), out decimal newCompare)
                && newValue >= newCompare)
            {
                string text = string.Format(
                    Resource.XCompareLessInvalid,
                    display, displayCompare);

                var message = new ValidationMessage(text, reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }

            return source;
        }
    }
}
