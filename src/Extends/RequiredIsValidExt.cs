using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RequiredIsValidExt
    {
        public static ValidationNotification RequiredIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.RequiredIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification RequiredIsValid(
            this ValidationNotification source, object value)
        {
            return source.RequiredIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use RequiredIsValid(IStructureToValidate data)")]
        private static ValidationNotification RequiredIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.RequiredIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification RequiredIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            RequiredIsValidAttribute validation = new RequiredIsValidAttribute();
            if(!source.Messages.Any(x => x.IsTypeError() && x.Reference?.ToLower() == data.Reference?.ToLower()))
            {
                if (!validation.IsValid(data.Value))
                {
                    string text = validation.FormatErrorMessage(data.Display);
                    var message = new ValidationMessage(text, data.Reference);
                    source.LastMessage = message;
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
