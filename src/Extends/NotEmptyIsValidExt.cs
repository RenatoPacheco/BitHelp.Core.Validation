using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class NotEmptyIsValidExt
    {
        public static ValidationNotification NotEmptyIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, bool ignoreWithSpace = false)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.NotEmptyIsValid(value, display, reference, ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, bool ignoreWithSpace = false)
        {
            return source.NotEmptyIsValid(value, Resource.DisplayValue, null, ignoreWithSpace);
        }

        private static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, string display, string reference, bool ignoreWithSpace)
        {
            source.LastMessage = null;
            NotEmptyIsValidAttribute validation = new NotEmptyIsValidAttribute(ignoreWithSpace);
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
