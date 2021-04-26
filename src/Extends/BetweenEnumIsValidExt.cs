using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenEnumIsValidExt
    {
        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(
                data.GetStructureToValidate(expression),
                options);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options);
        }

        [Obsolete("Use BetweenEnumIsValid(IStructureToValidate data, IEnumerable<Enum> options)")]
        private static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, object value, string display, string reference,
            IEnumerable<Enum> options)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, options);
        }

        private static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, IStructureToValidate data, IEnumerable<Enum> options)
        {
            source.LastMessage = null;
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(options);
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
