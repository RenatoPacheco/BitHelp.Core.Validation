using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxTimeSpanIsValidExt
    {
        public static ValidationNotification MaxTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, maximum);
        }

        [Obsolete("Use MaxTimeSpanIsValid(IStructureToValidate data, TimeSpan maximum)")]
        private static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, maximum);
        }

        private static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, TimeSpan maximum)
        {
            source.LastMessage = null;
            MaxTimeSpanIsValidAttribute validation = new MaxTimeSpanIsValidAttribute(maximum);
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
