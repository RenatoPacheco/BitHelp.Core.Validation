using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CompareLessDateTimeIsValidExt
    {
        public static ValidationNotification CompareLessDateTimeIsValid<TClass>(
            this ValidationNotification source, TClass data,
            Expression<Func<TClass, object>> expression,
            Expression<Func<TClass, object>> expressionCompare,
            CultureInfo cultureInfo = null)
        {
            string prorpety = expression.PropertyTrail();

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
