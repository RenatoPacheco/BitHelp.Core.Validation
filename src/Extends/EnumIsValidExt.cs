using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EnumIsValidExt
    {
        public static ValidationNotification EnumIsValid<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, Type type)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data, null);
            string display = expression.PropertyDisplay();
            return source.EnumIsValid(value, display, prorpety, type);
        }

        public static ValidationNotification EnumIsValid(
            this ValidationNotification source, object value, Type type)
        {
            return source.EnumIsValid(value, Resource.DisplayValue, null, type);
        }

        private static ValidationNotification EnumIsValid(
            this ValidationNotification source, object value, string display, string reference, Type type)
        {
            source.LastMessage = null;
            EnumIsValidAttribute validation = new EnumIsValidAttribute(type);
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
