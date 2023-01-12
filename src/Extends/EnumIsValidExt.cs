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
            this T source, 
            Expression<Func<T, P>> expression, 
            Type type, bool ignoreCase = false)
            where T : ISelfValidation
        {
            return source.EnumIsValid(
                source.GetStructureToValidate(expression),
                type, ignoreCase);
        }

        public static ValidationNotification EnumIsValid<T>(
            this T source, 
            object value, Type type, 
            bool ignoreCase = false)
            where T : ISelfValidation
        {
            return source.EnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, ignoreCase);
        }

        public static ValidationNotification EnumIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            Type type, bool ignoreCase = false)
            where T : ISelfValidation
        {
            return source.Notifications.EnumIsValid(data, type, ignoreCase);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification EnumIsValid<T, P>(
            this ValidationNotification source, 
            T data, Expression<Func<T, P>> expression, 
            Type type, bool ignoreCase = false)
        {
            return source.EnumIsValid(
                data.GetStructureToValidate(expression),
                type, ignoreCase);
        }

        public static ValidationNotification EnumIsValid(
            this ValidationNotification source, 
            object value, Type type, bool ignoreCase = false)
        {
            return source.EnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, type, ignoreCase);
        }

        public static ValidationNotification EnumIsValid(
            this ValidationNotification source, 
            IStructureToValidate data, Type type, 
            bool ignoreCase = false)
        {
            source.CleanLastMessage();
            EnumIsValidAttribute validation = new EnumIsValidAttribute(type, ignoreCase);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }

        #endregion ValidationNotification
    }
}
