using System;

namespace BitHelp.Core.Validation
{
    public class ValidationMessage
    {
        protected ValidationMessage()
        {
            this.Id = Guid.NewGuid();
            this.Date = DateTime.Now;
            this.Type = ValidationType.Error;
        }

        public ValidationMessage(
            string message, string reference = null, 
            ValidationType type = ValidationType.Error)
            : this()
        {
            this.Message = message;
            this.Reference = reference;
            this.Type = type;
        }

        public ValidationMessage(
            string message, ValidationType type)
            : this()
        {
            this.Message = message;
            this.Type = type;
        }

        public ValidationMessage(
            Exception exception, string reference = null,
            ValidationType type = ValidationType.Fatal)
            : this()
        {
            this.Message = exception.StackTrace;
            this.Exception = exception;
            this.Reference = reference;
            this.Type = type;
        }

        public Guid Id { get; set; }

        public string Message { get; set; }

        public string Reference { get; set; }

        public Exception Exception { get; set; }

        public ValidationType Type { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return this.Message;
        }

        public bool IsTypeError()
        {
            return (int)this.Type <= (int)ValidationType.Unauthorized;
        }

        public static bool IsTypeError(ValidationType type)
        {
            return (int)type >= (int)ValidationType.Unauthorized;
        }

        #region operator

        public override bool Equals(object obj)
        {
            ValidationMessage comparar = obj as ValidationMessage;
            return !object.Equals(comparar, null)
                && this.GetHashCode() == comparar.GetHashCode();
        }

        public override int GetHashCode()
        {
            return $"{this.Id}:{this.GetType()}".GetHashCode();
        }

        public static bool operator ==(ValidationMessage a, ValidationMessage b)
        {
            return object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));
        }

        public static bool operator !=(ValidationMessage a, ValidationMessage b)
        {
            return !(object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b)));
        }

        public static implicit operator ValidationMessage(string value)
        {
            return new ValidationMessage(value);
        }

        public static implicit operator string(ValidationMessage value)
        {
            return value?.ToString();
        }

        public static implicit operator ValidationMessage(Exception value)
        {
            return new ValidationMessage(value);
        }

        public static implicit operator Exception(ValidationMessage value)
        {
            return value?.Exception;
        }

        #endregion
    }
}
