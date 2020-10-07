using BitHelp.Core.Extend;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class SetMessageExt
    {
        public static ValidationNotification SetMessage(
            this ValidationNotification source, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = message;

            return source;
        }

        public static ValidationNotification SetMessage<T>(
            this ValidationNotification source, Expression<Func<T, object>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }

        public static ValidationNotification SetMessage<T, P>(
            this ValidationNotification source, Expression<Func<T, P>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }

        public static ValidationNotification SetMessage<T>(
            this ValidationNotification source, T _, Expression<Func<T, object>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }

        public static ValidationNotification SetMessage<T, P>(
            this ValidationNotification source, T _, Expression<Func<T, P>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }
    }
}
