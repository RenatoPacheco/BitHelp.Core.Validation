using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RegexIsValidExt
    {
        public static ValidationNotification RegexIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, string pattern, RegexOptions options = RegexOptions.None)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RegexIsValid(value, display, prorpety, pattern, options);
        }

        public static ValidationNotification RegexIsValid(
            this ValidationNotification source, object value, string pattern, RegexOptions options = RegexOptions.None)
        {
            return source.RegexIsValid(value, Resource.DisplayValue, null, pattern, options);
        }

        private static ValidationNotification RegexIsValid(
            this ValidationNotification source, object value, string display, string reference, string pattern, RegexOptions options = RegexOptions.None)
        {
            source.LastMessage = null;
            RegexIsValidAttribute validation = new RegexIsValidAttribute(pattern, options);
            if (!validation.IsValid(value))
            {
                string text = validation.FormatErrorMessage(display);
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
