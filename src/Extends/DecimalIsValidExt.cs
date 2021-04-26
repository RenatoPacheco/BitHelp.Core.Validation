using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DecimalIsValidExt
    {
        public static ValidationNotification DecimalIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.DecimalIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification DecimalIsValid(
            this ValidationNotification source, object value)
        {
            return source.DecimalIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use DecimalIsValid(IStructureToValidate data)")]
        private static ValidationNotification DecimalIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.DecimalIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        private static ValidationNotification DecimalIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            DecimalIsValidAttribute validation = new DecimalIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
