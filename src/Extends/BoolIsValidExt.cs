﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BoolIsValidExt
    {
        public static ValidationNotification BoolIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.BoolIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value)
        {
            return source.BoolIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use BoolIsValid(IStructureToValidate data)")]
        private static ValidationNotification BoolIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.BoolIsValid(new StructureToValidate { 
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        private static ValidationNotification BoolIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            BoolIsValidAttribute validation = new BoolIsValidAttribute();
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
