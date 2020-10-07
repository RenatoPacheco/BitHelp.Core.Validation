﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MinTimeSpanIsValidExt
    {
        public static ValidationNotification MinTimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, TimeSpan minimum)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MinTimeSpanIsValid(value, display, reference, minimum);
        }

        public static ValidationNotification MinTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan minimum)
        {
            return source.MinTimeSpanIsValid(value, Resource.DisplayValue, null, minimum);
        }

        private static ValidationNotification MinTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan minimum)
        {
            source.LastMessage = null;
            MinTimeSpanIsValidAttribute validation = new MinTimeSpanIsValidAttribute(minimum);
            if (!validation.IsValid(value))
            {
                string text = validation.FormatErrorMessage(display);
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
