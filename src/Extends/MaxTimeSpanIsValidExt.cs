﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxTimeSpanIsValidExt
    {
        public static ValidationNotification MaxTimeSpanIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, TimeSpan maximum)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MaxTimeSpanIsValid(value, display, prorpety, maximum);
        }

        public static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, TimeSpan maximum)
        {
            return source.MaxTimeSpanIsValid(value, Resource.DisplayValue, null, maximum);
        }

        private static ValidationNotification MaxTimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference, TimeSpan maximum)
        {
            source.LastMessage = null;
            MaxTimespanIsValidAttribute validation = new MaxTimespanIsValidAttribute(maximum);
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
