using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ConfirmedIsValidExt
    {
        public static ValidationNotification ConfirmedIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, object toConfirm)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.ConfirmedIsValid(value, display, prorpety, toConfirm);
        }

        public static ValidationNotification ConfirmedIsValid(
            this ValidationNotification source, object value, object toConfirm)
        {
            return source.ConfirmedIsValid(value, Resource.DisplayValue, null, toConfirm);
        }

        private static ValidationNotification ConfirmedIsValid(
            this ValidationNotification source, object value, string display, string reference, object toConfirm)
        {
            source.LastMessage = null;
            if (value != null && value != toConfirm)
            {
                string text = string.Format(Resource.XConfirmedInvalid, display);
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
