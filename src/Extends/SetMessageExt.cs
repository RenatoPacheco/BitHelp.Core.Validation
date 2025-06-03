using System;using BitHelp.Core.Extend;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class SetMessageExt
    {
        public static ValidationNotification SetMessage(
            this ValidationNotification source, string message)
        {
            message = message?.Trim();

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            foreach(var item in source.LastMessage) {
                if (item != null)
                    item.Message = string.Format(message, source.LastDisplayName);
            }

            return source;
        }

        public static ValidationNotification SetMessage<T>(
            this ValidationNotification source, Expression<Func<T, object>> expression, string message)
        {
            message = message?.Trim();

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            foreach (var item in source.LastMessage) {
                if (item != null)
                    item.Message = string.Format(message, expression.PropertyDisplay());
            }

            return source;
        }

        public static ValidationNotification SetMessage<T, P>(
            this ValidationNotification source, T _, Expression<Func<T, P>> expression, string message)
        {
            message = message?.Trim();

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            foreach (var item in source.LastMessage) {
                if (item != null)
                    item.Message = string.Format(message, expression.PropertyDisplay());
            }

            return source;
        }
    }
}
