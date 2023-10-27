using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;

namespace BitHelp.Core.Validation.Extends
{
    public static class HasNotificationExt
    {
        #region To ISelfValidation

        public static bool IsValid<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return !source.Notifications.Messages.Any(x => x.Reference == reference && x.IsTypeError());
        }

        public static bool IsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return !source.Messages.Any(x => x.Reference == reference && x.IsTypeError());
        }

        public static bool HasNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference);
        }

        public static bool HasNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference);
        }

        public static bool HasErrorNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Error
                && x.Reference == reference);
        }

        public static bool HasErrorNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Error 
                && x.Reference == reference);
        }

        public static bool HasFatalNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Fatal
                && x.Reference == reference);
        }

        public static bool HasFatalNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Fatal
                && x.Reference == reference);
        }

        public static bool HasUnauthorizedNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Unauthorized
                && x.Reference == reference);
        }

        public static bool HasUnauthorizedNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Unauthorized
                && x.Reference == reference);
        }

        public static bool HasSuccessNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Success 
                && x.Reference == reference);
        }

        public static bool HasSuccessNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Success
                && x.Reference == reference);
        }

        public static bool HasInfoNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Info
                && x.Reference == reference);
        }

        public static bool HasInfoNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Info 
                && x.Reference == reference);
        }

        public static bool HasAlertNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Type == ValidationType.Alert
                && x.Reference == reference);
        }

        public static bool HasAlertNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Type == ValidationType.Alert
                && x.Reference == reference);
        }

        #endregion
    }
}
