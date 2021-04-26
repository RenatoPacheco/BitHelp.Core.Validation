﻿using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeItemsIsValidExt
    {
        public static ValidationNotification RangeItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, IList value, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        [Obsolete("Use RangeItemsIsValid(IStructureToValidate data, int minimum, int maximum)")]
        private static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, object value, string display, string reference, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum, int maximum)
        {
            source.LastMessage = null;
            RangeItemsIsValidAttribute validation = new RangeItemsIsValidAttribute(minimum, maximum);
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
