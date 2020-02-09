using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ComparePlusNumberIsValidExt
    {
        public static ValidationNotification ComparePlusNumberIsValid<TClass>(
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
                if (decimal.TryParse(Convert.ToString(value), out decimal newValue)
                    && decimal.TryParse(Convert.ToString(valueCompare), out decimal newCompare)
                    && newValue <= newCompare)
                {
                    string text = string.Format(
                        Resource.XComparePlusInvalid,
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
