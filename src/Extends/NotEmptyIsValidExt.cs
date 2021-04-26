using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class NotEmptyIsValidExt
    {
        public static ValidationNotification NotEmptyIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, bool ignoreWithSpace = false)
        {
            return source.NotEmptyIsValid(
                data.GetStructureToValidate(expression),
                ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, bool ignoreWithSpace = false)
        {
            return source.NotEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, ignoreWithSpace);
        }

        [Obsolete("Use NotEmptyIsValid(IStructureToValidate data, bool ignoreWithSpace)")]
        private static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, object value, string display, string reference, bool ignoreWithSpace)
        {
            return source.NotEmptyIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, ignoreWithSpace);
        }

        public static ValidationNotification NotEmptyIsValid(
            this ValidationNotification source, IStructureToValidate data, bool ignoreWithSpace)
        {
            source.LastMessage = null;
            NotEmptyIsValidAttribute validation = new NotEmptyIsValidAttribute(ignoreWithSpace);
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
