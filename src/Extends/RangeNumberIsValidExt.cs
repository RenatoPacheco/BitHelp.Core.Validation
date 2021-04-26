using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeNumberIsValidExt
    {
        public static ValidationNotification RangeNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        [Obsolete("Use RangeNumberIsValid(IStructureToValidate data, decimal minimum, decimal maximum)")]
        private static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, decimal minimum, decimal maximum)
        {
            return source.RangeNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum, maximum);
        }

        private static ValidationNotification RangeNumberIsValid(
            this ValidationNotification source, IStructureToValidate data, decimal minimum, decimal maximum)
        {
            source.LastMessage = null;
            RangeNumberIsValidAttribute validation = new RangeNumberIsValidAttribute(minimum, maximum);
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
