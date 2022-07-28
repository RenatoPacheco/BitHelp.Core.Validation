using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EnumIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification EnumIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, Type type)
            where T : ISelfValidation
        {
            return source.EnumIsValid(
                source.GetStructureToValidate(expression),
                type);
        }

        public static ValidationNotification EnumIsValid<T>(
            this T source, object value, Type type)
            where T : ISelfValidation
        {
            return source.EnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type);
        }

        public static ValidationNotification EnumIsValid<T>(
            this T source, IStructureToValidate data, Type type)
            where T : ISelfValidation
        {
            return source.Notifications.EnumIsValid(data, type);
        }

        #endregion

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

        public static ValidationNotification EnumIsValid(
            this ValidationNotification source, IStructureToValidate data, Type type)
        {
            source.CleanLastMessage();
            EnumIsValidAttribute validation = new EnumIsValidAttribute(type);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }
    }
}
