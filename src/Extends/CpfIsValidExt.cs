﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class CpfIsValidExt
    {
        public static ValidationNotification CpfIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            return source.CpfIsValid(
                data.GetStructureToValidate(expression));
        }

        public static ValidationNotification CpfIsValid(
            this ValidationNotification source, object value)
        {
            return source.CpfIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            });
        }

        [Obsolete("Use CpfIsValid(IStructureToValidate data)")]
        private static ValidationNotification CpfIsValid(
            this ValidationNotification source, object value, string display, string reference)
        {
            return source.CpfIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            });
        }

        public static ValidationNotification CpfIsValid(
            this ValidationNotification source, IStructureToValidate data)
        {
            source.LastMessage = null;
            CpfIsValidAttribute validation = new CpfIsValidAttribute();
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
