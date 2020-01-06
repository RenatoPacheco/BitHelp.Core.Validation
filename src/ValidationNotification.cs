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
        
        public ValidationMessage LastMessage { get; set; }
        
        public void Add(ValidationMessage data)
        {
            this.Messages.Add(data);
        }

        public void Add(ISelfValidation data)
        {
            this.Messages = this.Messages.Concat(data.Notifications.Messages).ToList();
        }

        public void Add(ValidationNotification notification)
        {
            this.Messages = this.Messages.Concat(notification.Messages).ToList();
        }

        private void Add<T>(
            Expression<Func<T, object>> expression, string message,
            string reference, ValidationType type)
        {
            string display = expression.PropertyDisplay();

            reference = reference ?? expression.PropertyTrail();

            message = message ?? (ValidationMessage.IsTypeError(type) ? Resource.XNotValid : Resource.XValid);
            message = Regex.Replace(message, @"\{0\}", display);

            this.Messages.Add(new ValidationMessage(message, reference, type));
        }

        #region AddError

        public void AddError(
           string message, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, ValidationType.Error));
        }

        public void AddError<T>(
            Expression<Func<T, object>> expression,
            string message = null, string reference = null)
        {
            this.Add<T>(expression, message, reference, ValidationType.Error);
        }

        #endregion

        #region AddFatal

        public void AddFatal(
           Exception exception, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(exception, reference));
        }

        public void AddFatal<T>(
            Expression<Func<T, object>> expression, 
            Exception exception, string reference = null)
        {
            reference = reference ?? expression.PropertyTrail();
            this.Messages.Add(new ValidationMessage(exception, reference));
        }

        #endregion

        #region AddUnauthorized

        public void AddUnauthorized(
           string message, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, ValidationType.Unauthorized));
        }

        public void AddUnauthorized<T>(
            Expression<Func<T, object>> expression, 
            string message = null, string reference = null)
        {
            this.Add<T>(expression, message, reference, ValidationType.Unauthorized);
        }

        #endregion

        #region AddAlert

        public void AddAlert(
           string message, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, ValidationType.Alert));
        }

        public void AddAlert<T>(
            Expression<Func<T, object>> expression, 
            string message = null, string reference = null)
        {
            this.Add<T>(expression, message, reference, ValidationType.Alert);
        }

        #endregion

        #region AddSuccess

        public void AddSuccess(
           string message, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, ValidationType.Success));
        }

        public void AddSuccess<T>(
            Expression<Func<T, object>> expression, 
            string message = null, string reference = null)
        {
            this.Add<T>(expression, message, reference, ValidationType.Success);
        }

        #endregion

        #region AddInfo

        public void AddInfo(
           string message, string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, ValidationType.Info));
        }

        public void AddInfo<T>(
            Expression<Func<T, object>> expression, string message = null,
            string reference = null)
        {
            this.Add<T>(expression, message, reference, ValidationType.Info);
        }

        #endregion

        public bool IsValid()
        {
            return !this.Messages.Any(x => x.IsTypeError());
        }

        public bool AnyTypeError()
        {
            return this.Messages.Any(x => x.IsTypeError());
        }

        public void Clear()
        {
            this.Messages.Clear();
        }

        public void RemoveAtReference(string reference)
        {
            reference = reference?.ToLower();
            this.Messages = this.Messages.Where(x => x.Reference?.ToLower() == reference).ToList();
        }
    }
}
