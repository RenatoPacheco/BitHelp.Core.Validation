using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ComparePlusDateTimeIsValidExt
    {
        public static ValidationNotification ComparePlusDateTimeIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare,
            CultureInfo cultureInfo = null)
        {
            string reference = expression.PropertyTrail();

            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();

            object valueCompare = expressionCompare.Compile().DynamicInvoke(data);
            string displayCompare = expressionCompare.PropertyDisplay();

            cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;
            source.LastMessage = null;

            if (!(value is null) && !(valueCompare is null))
            {
                if (DateTime.TryParse(Convert.ToString(value), cultureInfo, DateTimeStyles.None, out DateTime newValue)
                    && DateTime.TryParse(Convert.ToString(valueCompare), cultureInfo, DateTimeStyles.None, out DateTime newCompare)
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
