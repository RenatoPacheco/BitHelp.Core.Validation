using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxNumberIsValidExt
    {
        public static ValidationNotification MaxNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal maximum)
        {
            return source.MaxNumberIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxNumberIsValid(
            this ValidationNotification source, object value, decimal maximum)
        {
            return source.MaxNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        [Obsolete("Use MaxNumberIsValid(IStructureToValidate data, decimal maximum)")]
        private static ValidationNotification MaxNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal maximum)
        {
            return source.MaxNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, maximum);
        }

        private static ValidationNotification MaxNumberIsValid(
            this ValidationNotification source, IStructureToValidate data, decimal maximum)
        {
            source.LastMessage = null;
            MaxNumberIsValidAttribute validation = new MaxNumberIsValidAttribute(maximum);
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
