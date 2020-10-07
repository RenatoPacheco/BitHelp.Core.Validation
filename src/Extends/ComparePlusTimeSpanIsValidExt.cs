using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ComparePlusTimeSpanIsValidExt
    {
        public static ValidationNotification ComparePlusTimeSpanIsValid<T, P, PCompare>(
            this ValidationNotification source, T data,
            Expression<Func<T, P>> expression,
            Expression<Func<T, PCompare>> expressionCompare)
        {
            string reference = expression.PropertyTrail();

            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();

            object valueCompare = expressionCompare.Compile().DynamicInvoke(data);
            string displayCompare = expressionCompare.PropertyDisplay();

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
