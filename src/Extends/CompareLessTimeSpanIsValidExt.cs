using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification CompareLessTimeSpanIsValid<T, P, PCompare>(
            this T source, Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
            where T : ISelfValidation
        {
            return source.CompareLessTimeSpanIsValid(
                source.GetStructureToValidate(expression),
                source.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification CompareLessTimeSpanIsValid<T>(
            this T source, IStructureToValidate data,
            IStructureToValidate dataCompare)
            where T : ISelfValidation
        {
            return source.Notifications.CompareLessTimeSpanIsValid(data, dataCompare);
        }

        #endregion

        public static ValidationNotification CompareLessTimeSpanIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
        {
            return source.CompareLessTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                data.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification CompareLessTimeSpanIsValid(
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
                && TimeSpan.TryParse(Convert.ToString(value), out TimeSpan newValue)
                && TimeSpan.TryParse(Convert.ToString(valueCompare), out TimeSpan newCompare)
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
