using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RequiredIfOtherNotNullIsValidExt
    {
        public static ValidationNotification RequiredIfOtherNotNullIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, object compare)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RequiredIfOtherNotNullIsValid(value, display, reference, compare);
        }

        public static ValidationNotification RequiredIfOtherNotNullIsValid(
            this ValidationNotification source, object value, object compare)
        {
            return source.RequiredIfOtherNotNullIsValid(value, Resource.DisplayValue, null, compare);
        }

        private static ValidationNotification RequiredIfOtherNotNullIsValid(
            this ValidationNotification source, object value, string display, string reference, object compare)
        {
            source.LastMessage = null;
            if(!source.Messages.Any(x => x.IsTypeError() && x.Reference?.ToLower() == reference?.ToLower()))
            {
                if (!object.Equals(compare, null) && object.Equals(value, null))
                {
                    string text = string.Format(Resource.XRequired, display);
                    var message = new ValidationMessage(text, reference);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
