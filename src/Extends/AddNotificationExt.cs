using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;

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
                source, expression, message, reference, exception);
        }

        public static void AddFatalNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            Exception exception, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddFatal(
                source, expression, exception, reference);
        }

        public static void AddUnauthorizedNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
            where T : ISelfValidation
        {
            source.Notifications.AddUnauthorized(
                source, expression, message, reference, exception);
        }

        public static void AddSuccessNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddSuccess(
                source, expression, message, reference);
        }

        public static void AddInfoNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddInfo(
                source, expression, message, reference);
        }

        public static void AddAlertNotification<T, P>(
            this T source, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
            where T : ISelfValidation
        {
            source.Notifications.AddAlert(
                source, expression, message, reference);
        }

        #endregion
    }
}
