using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class LongIsValidExt
    {
        public static ValidationNotification LongIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.LongIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification LongIsValid(
            this ValidationNotification source, object value)
        {
            return source.LongIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use LongIsValid(IStructureToValidate data)")]
        private static ValidationNotification LongIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.LongIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification LongIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            LongIsValidAttribute validation = new LongIsValidAttribute();
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
