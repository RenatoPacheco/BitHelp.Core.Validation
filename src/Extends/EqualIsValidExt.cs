using System;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualIsValidExt
    {
        public static ValidationNotification EqualIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, object compare)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.EqualIsValid(value, display, reference, compare);
        }

        public static ValidationNotification EqualIsValid(
            this ValidationNotification source, object value, object compare)
        {
            return source.EqualIsValid(value, Resource.DisplayValue, null, compare);
        }

        private static ValidationNotification EqualIsValid(
            this ValidationNotification source, object value, string display, string reference, object compare)
        {
            source.LastMessage = null;
            if(value != null && compare != null)
            {
                string valueCheck = Convert.ToString(value);
                string compareCheck = Convert.ToString(compare);
                if (valueCheck != compareCheck)
                {
                    string text = string.Format(Resource.XConfirmedInvalid, display);
                    var message = new ValidationMessage(text, reference);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
