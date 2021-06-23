using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class TimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification TimeSpanIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            return source.TimeSpanIsValid(
                source.GetStructureToValidate(expression));
        }

        public static ValidationNotification TimeSpanIsValid<T>(
            this T source, object value)
            where T : ISelfValidation
        {
            return source.TimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        public static ValidationNotification TimeSpanIsValid<T>(
            this T source, IStructureToValidate data)
            where T : ISelfValidation
        {
            return source.Notifications.TimeSpanIsValid(data);
        }

        #endregion

        public static ValidationNotification TimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.TimeSpanIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value)
        {
            return source.TimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use TimeSpanIsValid(IStructureToValidate data)")]
        private static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.TimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.CleanLastMessage();
            TimeSpanIsValidAttribute validation = new TimeSpanIsValidAttribute();
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
