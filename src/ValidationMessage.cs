﻿using System;

namespace BitHelp.Core.Validation {

    public class ValidationMessage
        : ICloneable, IEquatable<ValidationMessage> {

        protected ValidationMessage() {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Type = ValidationType.Error;
        }

        public ValidationMessage(
            string message, string reference = null,
            ValidationType type = ValidationType.Error)
            : this() {
            Message = message;
            Reference = reference;
            Type = type;
        }

        public ValidationMessage(
            string message, ValidationType type)
            : this() {
            Message = message;
            Type = type;
        }

        public ValidationMessage(
            Exception exception, string reference = null,
            ValidationType type = ValidationType.Fatal)
            : this() {
            Message = exception?.Message ?? exception?.StackTrace ?? "Exception";
            Exception = exception;
            Reference = reference;
            Type = type;
        }

        public Guid Id { get; set; }

        public string Message { get; set; }

        private string _reference;
        public string Reference {
            get => _reference;
            set => _reference = value?.Trim();
        }

        public Exception Exception { get; set; }

        public ValidationType Type { get; set; }

        public DateTime Date { get; set; }

        public override string ToString() {
            return Message;
        }

        public bool IsTypeError() {
            return IsTypeError(Type);
        }

        public static bool IsTypeError(ValidationType type) {
            return (int)type <= (int)ValidationType.NotFound;
        }

        #region operator

        public bool Equals(ValidationMessage other) {
            return other != null
                && Message == other.Message
                && Reference == other.Reference
                && Type == other.Type
                && Exception == other.Exception;
        }

        public override bool Equals(object obj) {
            return obj is ValidationMessage value && Equals(value);
        }

        public override int GetHashCode() {
            return $"{Id}:{GetType()}".GetHashCode();
        }

        public static bool operator ==(ValidationMessage a, ValidationMessage b) {
            return (Equals(a, null) && Equals(b, null))
                || (a?.Equals(b) ?? false);
        }

        public static bool operator !=(ValidationMessage a, ValidationMessage b) {
            return !(a == b);
        }

        public static implicit operator ValidationMessage(string value) {
            return value is null ? null : new ValidationMessage(value);
        }

        public static implicit operator string(ValidationMessage value) {
            return value?.ToString();
        }

        public static implicit operator ValidationMessage(Exception value) {
            return value is null ? null : new ValidationMessage(value);
        }

        public static implicit operator Exception(ValidationMessage value) {
            return value?.Exception;
        }

        #endregion

        public object Clone() {
            return MemberwiseClone();
        }
    }
}
