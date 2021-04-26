using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessDateTimeIsValidExt
    {
        public static ValidationNotification CompareLessDateTimeIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare,
            CultureInfo cultureInfo = null)
        {
            return source.CompareLessDateTimeIsValid(
                data.GetStructureToValidate(expression),
                data.GetStructureToValidate(expressionCompare),
                cultureInfo);
        }

        public static ValidationNotification CompareLessDateTimeIsValid(
            this ValidationNotification source,
            IStructureToValidate data,
            IStructureToValidate dataCompare,
            CultureInfo cultureInfo = null)
        {
            string reference = data.Reference;

            object value = data.Value;
            string display = data.Display;

            object valueCompare = dataCompare.Value;
            string displayCompare = dataCompare.Display;

            cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;
            source.LastMessage = null;

            if (!(value is null) && !(valueCompare is null))
            {
                if (DateTime.TryParse(Convert.ToString(value), cultureInfo, DateTimeStyles.None, out DateTime newValue)
                    && DateTime.TryParse(Convert.ToString(valueCompare), cultureInfo, DateTimeStyles.None, out DateTime newCompare)
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
