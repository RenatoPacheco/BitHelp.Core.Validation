using System;
using System.Collections;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification ExactItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression,
            int exact)
            where T : ISelfValidation
        {
            return source.ExactItemsIsValid(
                source.GetStructureToValidate(expression),
                exact);
        }

        public static ValidationNotification ExactItemsIsValid<T>(
            this T source, IEnumerable value, int exact)
            where T : ISelfValidation
        {
            return source.ExactItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, exact);
        }

        public static ValidationNotification ExactItemsIsValid<T>(
            this T source, IStructureToValidate data, int exact)
            where T : ISelfValidation
        {
            return source.Notifications.ExactItemsIsValid(data, exact);
        }

        #endregion

        public static ValidationNotification ExactItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression, int exact)
        {
            return source.ExactItemsIsValid(
                data.GetStructureToValidate(expression),
                exact);
        }

        public static ValidationNotification ExactItemsIsValid(
            this ValidationNotification source, IEnumerable value, int exact)
        {
            return source.ExactItemsIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, exact);
        }

        public static ValidationNotification ExactItemsIsValid(
            this ValidationNotification source, IStructureToValidate data, int exact)
        {
            source.CleanLastMessage();
            ExactItemsIsValidAttribute validation = new ExactItemsIsValidAttribute(exact);
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
