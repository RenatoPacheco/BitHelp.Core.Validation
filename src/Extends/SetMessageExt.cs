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

        public static ValidationNotification SetMessage<TClass>(
            this ValidationNotification source, Expression<Func<TClass, object>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }

        public static ValidationNotification SetMessage<TClass>(
            this ValidationNotification source, TClass _, Expression<Func<TClass, object>> expression, string message)
        {
            if (string.IsNullOrEmpty(message?.Trim()))
                throw new ArgumentNullException(nameof(message));

            if (source.LastMessage != null)
                source.LastMessage.Message = string.Format(message.Trim(), expression.PropertyDisplay());

            return source;
        }
    }
}
