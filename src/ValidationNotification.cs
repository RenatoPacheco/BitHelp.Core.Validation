using System;
using System.Linq;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation
{
    public class ValidationNotification
    {
        public IList<ValidationMessage> Messages { get; set; } = new List<ValidationMessage>();

        public ValidationMessage LastMessage { get; set; } = Resource.DisplayValue;

        public ValidationMessage LastDisplayName { get; protected set; }

        public void SetLastMessage(ValidationMessage message, string displayName)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentNullException(nameof(displayName));

            LastMessage = message;
            LastDisplayName = displayName;
        }

        public void CleanLastMessage()
        {
            LastMessage = null;
            LastDisplayName = Resource.DisplayValue;
        }

        public void Add(ValidationMessage message)
        {
            Messages.Add(message);
        }

        public void Add(ISelfValidation data)
        {
            Messages = Messages.Concat(data.Notifications.Messages).ToList();
        }

        public void Add(ISelfValidation data, string prefix)
        {
            int total = data.Notifications.Messages.Count();
            for (int i = 0; i < total; i++)
            {
                ValidationMessage message = (ValidationMessage)data.Notifications.Messages[i].Clone();
                message.Reference = string.IsNullOrWhiteSpace(message.Reference) ? prefix
                    : $"{prefix}.{message.Reference}";
                this.Add(message);
            }
        }

        public void Add(ValidationNotification notification)
        {
            Messages = Messages.Concat(notification.Messages).ToList();
        }

        private void Add<T>(
            Expression<Func<T, object>> expression, string message,
            string reference, ValidationType type, Exception exception = null)
        {
            string display = expression.PropertyDisplay();

            reference = reference ?? expression.PropertyTrail();

            message = message ?? (ValidationMessage.IsTypeError(type) ? Resource.XNotValid : Resource.XValid);
            message = Regex.Replace(message, @"\{0\}", display);

            Messages.Add(new ValidationMessage(message, reference, type) { Exception = exception });
        }

        private void Add<T, P>(
            Expression<Func<T, P>> expression, string message,
            string reference, ValidationType type, Exception exception = null)
        {
            string display = expression.PropertyDisplay();

            reference = reference ?? expression.PropertyTrail();

            message = message ?? (ValidationMessage.IsTypeError(type) ? Resource.XNotValid : Resource.XValid);
            message = Regex.Replace(message, @"\{0\}", display);

            Messages.Add(new ValidationMessage(message, reference, type) { Exception = exception });
        }

        #region AddError

        public void AddError(
           string message, string reference = null, Exception exception = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.Error) { Exception = exception });
        }

        public void AddError<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Error, exception);
        }

        public void AddError<T, P>(
            T _, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Error, exception);
        }

        #endregion

        #region AddFatal

        public void AddFatal(
           Exception exception, string reference = null)
        {
            Messages.Add(new ValidationMessage(exception, reference));
        }

        public void AddFatal<T>(
            Expression<Func<T, object>> expression,
            Exception exception, string reference = null)
        {
            reference = reference ?? expression.PropertyTrail();
            Messages.Add(new ValidationMessage(exception, reference));
        }

        public void AddFatal<T, P>(
            T _, Expression<Func<T, P>> expression,
            Exception exception, string reference = null)
        {
            reference = reference ?? expression.PropertyTrail();
            Messages.Add(new ValidationMessage(exception, reference));
        }

        #endregion

        #region AddUnauthorized

        public void AddUnauthorized(
           string message, string reference = null, Exception exception = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.Unauthorized) { Exception = exception });
        }

        public void AddUnauthorized<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Unauthorized, exception);
        }

        public void AddUnauthorized<T, P>(
            T _, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Unauthorized, exception);
        }

        #endregion

        #region AddNotFound

        public void AddNotFound(
           string message, string reference = null, Exception exception = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.NotFound) { Exception = exception });
        }

        public void AddNotFound<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.NotFound, exception);
        }

        public void AddNotFound<T, P>(
            T _, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.NotFound, exception);
        }

        #endregion

        #region AddAlert

        public void AddAlert(
           string message, string reference = null, Exception exception = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.Alert) { Exception = exception });
        }

        public void AddAlert<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Alert, exception);
        }

        public void AddAlert<T, P>(
            T _, Expression<Func<T, P>> expression,
            string message = null, string reference = null, Exception exception = null)
        {
            Add(expression, message, reference, ValidationType.Alert, exception);
        }

        #endregion

        #region AddSuccess

        public void AddSuccess(
           string message, string reference = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.Success));
        }

        public void AddSuccess<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null)
        {
            Add(expression, message, reference, ValidationType.Success);
        }

        public void AddSuccess<T, P>(
            T _, Expression<Func<T, P>> expression,
            string message = null, string reference = null)
        {
            Add(expression, message, reference, ValidationType.Success);
        }

        #endregion

        #region AddInfo

        public void AddInfo(
           string message, string reference = null)
        {
            Messages.Add(new ValidationMessage(message, reference, ValidationType.Info));
        }

        public void AddInfo<T>(
            Expression<Func<T, object>> expression, string message = null,
            string reference = null)
        {
            Add(expression, message, reference, ValidationType.Info);
        }

        public void AddInfo<T, P>(
            T _, Expression<Func<T, P>> expression, string message = null,
            string reference = null)
        {
            Add(expression, message, reference, ValidationType.Info);
        }

        #endregion

        public bool IsValid()
        {
            return !Messages.Any(x => x.IsTypeError());
        }

        public bool AnyTypeError()
        {
            return Messages.Any(x => x.IsTypeError());
        }

        public void Clear()
        {
            LastMessage = null;
            Messages.Clear();
        }

        public void RemoveAtReference(string reference)
        {
            reference = reference?.ToLower() ?? string.Empty;
            string referencePrefix = $"{reference}.";
            Messages = Messages.Where(x =>
            {
                string compare = x.Reference?.ToLower() ?? string.Empty;
                return compare != reference && compare.IndexOf(referencePrefix) != 0;
            }).ToList();
        }

        public void RemoveAtReference<T>(Expression<Func<T, object>> expression)
        {
            string reference = expression.PropertyTrail();
            RemoveAtReference(reference);
        }

        public void RemoveAtReference<T, P>(Expression<Func<T, P>> expression)
        {
            string reference = expression.PropertyTrail();
            RemoveAtReference(reference);
        }
    }
}
