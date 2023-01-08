﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class BetweenTimeSpanIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this T source, 
            Expression<Func<T, P>> expression, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenTimeSpanIsValid(
                source.GetStructureToValidate(expression), options, denay);
        }

        public static ValidationNotification BetweenTimeSpanIsValid<T>(
            this T source, 
            object value, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenTimeSpanIsValid<T>(
            this T source,
            IStructureToValidate data, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
            where T : ISelfValidation
        {
            return source.Notifications.BetweenTimeSpanIsValid(data, options, denay);
        }

        #endregion

        public static ValidationNotification BetweenTimeSpanIsValid<T, P>(
            this ValidationNotification source, 
            T data, 
            Expression<Func<T, P>> expression, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
        {
            return source.BetweenTimeSpanIsValid(
                data.GetStructureToValidate(expression),
                options, denay);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source,
            object value, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
        {
            return source.BetweenTimeSpanIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, options, denay);
        }

        public static ValidationNotification BetweenTimeSpanIsValid(
            this ValidationNotification source,
            IStructureToValidate data, 
            IEnumerable<TimeSpan> options,
            bool denay = false)
        {
            source.CleanLastMessage();
            BetweenTimeSpanIsValidAttribute validation = new BetweenTimeSpanIsValidAttribute(options, denay);
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
