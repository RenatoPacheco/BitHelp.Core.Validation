using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenNumberIsValidExt
    {
        public static ValidationNotification BetweenNumberIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<decimal> options)
        {
            return source.BetweenNumberIsValid(
                data.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, object value, IEnumerable<decimal> options)
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        [Obsolete("Use BetweenNumberIsValid(IStructureToValidate data, IEnumerable<Enum> options)")]
        private static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, object value, string display, string reference, IEnumerable<decimal> options)
        {
            return source.BetweenNumberIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, options);
        }

        private static ValidationNotification BetweenNumberIsValid(
            this ValidationNotification source, IStructureToValidate data, IEnumerable<decimal> options)
        {
            source.LastMessage = null;
            BetweenNumberIsValidAttribute validation = new BetweenNumberIsValidAttribute(options);
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
