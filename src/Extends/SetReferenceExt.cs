﻿using System;
using BitHelp.Core.Extend;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class SetReferenceExt
    {
        public static ValidationNotification SetReference<T>(
            this ValidationNotification source, Expression<Func<T, object>> expression)
        {
            if (source.LastMessage != null)
                source.LastMessage.Reference = expression.PropertyPath();

            return source;
        }

        public static ValidationNotification SetReference<T>(
            this ValidationNotification source, T _, Expression<Func<T, object>> expression)
        {
            if (source.LastMessage != null)
                source.LastMessage.Reference = expression.PropertyPath();

            return source;
        }

        public static ValidationNotification SetReference(
            this ValidationNotification source, string reference)
        {
            if (source.LastMessage != null)
                source.LastMessage.Reference = reference?.Trim();

            return source;
        }
    }
}
