using System;
using BitHelp.Core.Extend;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class SetReferenceExt
    {
        public static ValidationNotification SetReference<T>(
            this ValidationNotification source, Expression<Func<T, object>> expression)
        {
            foreach (var item in source.LastMessage) {
                if (item != null)
                    item.Reference = expression.PropertyPath();
            }

            return source;
        }

        public static ValidationNotification SetReference<T>(
            this ValidationNotification source, T _, Expression<Func<T, object>> expression)
        {
            foreach (var item in source.LastMessage) {
                if (item != null)
                    item.Reference = expression.PropertyPath();
            }

            return source;
        }

        public static ValidationNotification SetReference(
            this ValidationNotification source, string reference)
        {
            foreach (var item in source.LastMessage) {
                if (item != null)
                    item.Reference = reference?.Trim();
            }

            return source;
        }
    }
}
