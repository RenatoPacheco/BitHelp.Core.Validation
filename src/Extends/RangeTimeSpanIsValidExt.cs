using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeTimeSpanIsValidExt
    {
        public static ValidationNotification RangeTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        [Obsolete("Use RangeTimeSpanIsValid(IStructureToValidate data, TimeSpan minimum, TimeSpan maximum)")]
        private static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan minimum, TimeSpan maximum)
        {
            return source.RangeTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum, maximum);
        }

        public static ValidationNotification RangeTimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data, TimeSpan minimum, TimeSpan maximum)
        {
            source.LastMessage = null;
            RangeTimeSpanIsValidAttribute validation = new RangeTimeSpanIsValidAttribute(minimum, maximum);
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
