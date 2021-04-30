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
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Error);
        }

        public static bool HasErrorNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Error);
        }

        public static bool HasFatalNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Fatal);
        }

        public static bool HasFatalNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Fatal);
        }

        public static bool HasUnauthorizedNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Unauthorized);
        }

        public static bool HasUnauthorizedNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Unauthorized);
        }

        public static bool HasSuccessNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Success);
        }

        public static bool HasSuccessNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Success);
        }

        public static bool HasInfoNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Info);
        }

        public static bool HasInfoNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Info);
        }

        public static bool HasAlertNotification<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = source.GetStructureToValidate(expression).Reference;
            return source.Notifications.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Alert);
        }

        public static bool HasAlertNotification<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = data.GetStructureToValidate(expression).Reference;
            return source.Messages.Any(x => x.Reference == reference
                && x.Type == ValidationType.Alert);
        }

        #endregion
    }
}
