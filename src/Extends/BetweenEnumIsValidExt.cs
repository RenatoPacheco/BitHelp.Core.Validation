﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenEnumIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<Enum> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(
                source.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<Enum> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenEnumIsValid<T>(
            this T source, 
            IStructureToValidate data, 
            IEnumerable<Enum> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenEnumIsValid(data, options, denay);
        }

        #endregion

        public static ValidationNotification BetweenEnumIsValid<T, P>(
            this ValidationNotification source, T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<Enum> options,
            bool denay = false)
        {
            return source.BetweenEnumIsValid(
                data.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            object value, 
            IEnumerable<Enum> options,
            bool denay = false)
        {
            return source.BetweenEnumIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenEnumIsValid(
            this ValidationNotification source, 
            IStructureToValidate data, 
            IEnumerable<Enum> options,
            bool denay = false)
        {
            source.CleanLastMessage();
            BetweenEnumIsValidAttribute validation = new BetweenEnumIsValidAttribute(options, denay);
            if (!validation.IsValid(data.Value))
            {
                string text = validation.FormatErrorMessage(data.Display);
                var message = new ValidationMessage(text, data.Reference);
                source.SetLastMessage(message, data.Display);
                source.Add(message);
            }
            return source;
        }
    }
}
