using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class AddNotificationExt
    {
        #region To ISelfValidation

        public static void AddErrorNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
            where T : ISelfValidation
        {
            source.Notifications.AddError(
                expression, message, reference, exception);
        }

        public static void AddFatalNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            Exception exception, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddFatal(
                expression, exception, reference);
        }

        public static void AddUnauthorizedNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
            where T : ISelfValidation
        {
            source.Notifications.AddUnauthorized(
                expression, message, reference, exception);
        }

        public static void AddSuccessNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddSuccess(
                expression, message, reference);
        }

        public static void AddInfoNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddInfo(
                expression, message, reference);
        }

        public static void AddAlertNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddAlert(
                expression, message, reference);
        }

        #endregion
    }
}
