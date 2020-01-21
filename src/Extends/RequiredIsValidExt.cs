using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RequiredIsValidExt
    {
        public static ValidationNotification RequiredIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.RequiredIsValid(value, display, prorpety);
        }

        public static ValidationNotification RequiredIsValid(
            this ValidationNotification source, object value)
        {
            return source.RequiredIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification RequiredIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            RequiredIsValidAttribute validation = new RequiredIsValidAttribute();
            if(!source.Messages.Any(x => x.IsTypeError() && x.Reference?.ToLower() == reference?.ToLower()))
            {
                if (!validation.IsValid(value))
                {
                    string text = validation.FormatErrorMessage(display);
                    var message = new ValidationMessage(text, reference);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
