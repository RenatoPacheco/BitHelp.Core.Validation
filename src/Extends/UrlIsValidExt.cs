﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class UrlIsValidExt
    {
        public static ValidationNotification UrlIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            string reference = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.UrlIsValid(value, display, reference);
        }

        public static ValidationNotification UrlIsValid(
            this ValidationNotification source, object value)
        {
            return source.UrlIsValid(value, Resource.DisplayValue, null);
        }

        private static ValidationNotification UrlIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            UrlIsValidAttribute validation = new UrlIsValidAttribute();
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
