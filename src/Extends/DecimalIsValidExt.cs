using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class DecimalIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification DecimalIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.DecimalIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification DecimalIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.DecimalIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification DecimalIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.DecimalIsValid(data);
        }

        #endregion

        #region ValidationNotification

        public static ValidationNotification DecimalIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.DecimalIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification DecimalIsValid(
            this ValidationNotification source, object value)
        {
            return source.DecimalIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification DecimalIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            DecimalIsValidAttribute validation = new DecimalIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }

        #endregion
    }
}
