using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RangeItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RangeItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression,int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.RangeItemsIsValid(
                source.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid<T>(
            this T source, IEnumerable value, int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.RangeItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid<T>(
            this T source, IStructureToValidate data, int minimum, int maximum)
            where T : ISelfValidation
        {
            return source.Notifications.RangeItemsIsValid(data, minimum, maximum);
        }

        #endregion

        public static ValidationNotification RangeItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(
                data.GetStructureToValidate(expression),
                minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, IEnumerable value, int minimum, int maximum)
        {
            return source.RangeItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, minimum, maximum);
        }

        public static ValidationNotification RangeItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int minimum, int maximum)
        {
            source.CleanLastMessage();
            RangeItemsIsValidAttribute validation = new RangeItemsIsValidAttribute(minimum, maximum);
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
