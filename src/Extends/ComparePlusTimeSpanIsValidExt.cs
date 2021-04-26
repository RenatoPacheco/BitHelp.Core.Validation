using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ComparePlusTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification ComparePlusTimeSpanIsValid<T, P, PCompare>(
            this T source, Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
            where T : ISelfValidation
        {
            return source.ComparePlusTimeSpanIsValid(
                source.GetStructureToValidate(expression),
                source.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification ComparePlusTimeSpanIsValid<T>(
            this T source, IStructureToValidate data,
            IStructureToValidate dataCompare)
            where T : ISelfValidation
        {
            return source.Notifications.ComparePlusTimeSpanIsValid(data, dataCompare);
        }

        #endregion

        public static ValidationNotification ComparePlusTimeSpanIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
        {
            return source.ComparePlusTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                data.GetStructureToValidate(expressionCompare));
        }

        public static ValidationNotification ComparePlusTimeSpanIsValid(
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
                if (TimeSpan.TryParse(Convert.ToString(value), out TimeSpan newValue)
                    && TimeSpan.TryParse(Convert.ToString(valueCompare), out TimeSpan newCompare)
                    && newValue <= newCompare)
                {
                    string text = string.Format(
                        Resource.XComparePlusInvalid,
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
