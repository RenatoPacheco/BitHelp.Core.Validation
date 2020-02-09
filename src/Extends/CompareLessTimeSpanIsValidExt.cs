using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessTimeSpanIsValidExt
    {
        public static ValidationNotification CompareLessTimeSpanIsValid<TClass>(
            this ValidationNotification source, TClass data,
            Expression<Func<TClass, object>> expression,
            Expression<Func<TClass, object>> expressionCompare)
        {
            string prorpety = expression.PropertyTrail();

            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();

            object valueCompare = expressionCompare.Compile().DynamicInvoke(data);
            string displayCompare = expressionCompare.PropertyDisplay();

            source.LastMessage = null;

            if (!(value is null) && !(valueCompare is null))
            {
                if (TimeSpan.TryParse(Convert.ToString(value), out TimeSpan newValue)
                    && TimeSpan.TryParse(Convert.ToString(valueCompare), out TimeSpan newCompare)
                    && newValue >= newCompare)
                {
                    string text = string.Format(
                        Resource.XCompareLessInvalid,
                        display, displayCompare);

                    var message = new ValidationMessage(text, prorpety);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }

            return source;
        }
    }
}
