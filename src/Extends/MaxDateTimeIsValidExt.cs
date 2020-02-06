﻿using System;
using System.Globalization;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class MaxDateTimeIsValidExt
    {
        public static ValidationNotification MaxDateTimeIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, object>> expression, DateTime maximum, CultureInfo cultureInfo = null)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.Compile().DynamicInvoke(data);
            string display = expression.PropertyDisplay();
            return source.MaxDateTimeIsValid(value, display, prorpety, maximum, cultureInfo);
        }

        public static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, object value, DateTime maximum, CultureInfo cultureInfo = null)
        {
            return source.MaxDateTimeIsValid(value, Resource.DisplayValue, null, maximum, cultureInfo);
        }

        private static ValidationNotification MaxDateTimeIsValid(
            this ValidationNotification source, object value, string display, string reference, DateTime maximum, CultureInfo cultureInfo)
        {
            source.LastMessage = null;
            MaxDateTimeIsValidAttribute validation = new MaxDateTimeIsValidAttribute(maximum, cultureInfo);
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