﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class TimeSpanIsValidExt
    {
        public static ValidationNotification TimeSpanIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.TimeSpanIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value)
        {
            return source.TimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use TimeSpanIsValid(IStructureToValidate data)")]
        private static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.TimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        private static ValidationNotification TimeSpanIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            TimeSpanIsValidAttribute validation = new TimeSpanIsValidAttribute();
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
