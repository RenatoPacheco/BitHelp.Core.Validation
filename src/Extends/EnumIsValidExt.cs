using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EnumIsValidExt
    {
        public static ValidationNotification EnumIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, Type type)
        {
            return source.EnumIsValid(
                data.GetStructureToValidate(expression),
                type);
        }

        public static ValidationNotification EnumIsValid(
            this ValidationNotification source, object value, Type type)
        {
            return source.EnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type);
        }

        [Obsolete("Use EnumIsValid(IStructureToValidate data, Type type)")]
        private static ValidationNotification EnumIsValid(
            this ValidationNotification source, object value, string display, string reference, Type type)
        {
            return source.EnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, type);
        }

        private static ValidationNotification EnumIsValid(
            this ValidationNotification source, IStructureToValidate data, Type type)
        {
            source.LastMessage = null;
            EnumIsValidAttribute validation = new EnumIsValidAttribute(type);
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
