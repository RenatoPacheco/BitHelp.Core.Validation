using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactCharactersIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification ExactCharactersIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression,
            int exact)
            where T : ISelfValidation
        {
            return source.ExactCharactersIsValid(
                source.GetStructureToValidate(expression),
                exact);
        }

        public static ValidationNotification ExactCharactersIsValid<T>(
            this T source, object value,
            int exact)
            where T : ISelfValidation
        {
            return source.ExactCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, exact);
        }

        public static ValidationNotification ExactCharactersIsValid<T>(
            this T source, IStructureToValidate data,
            int exact)
            where T : ISelfValidation
        {
            return source.Notifications.ExactCharactersIsValid(data, exact);
        }

        #endregion

        public static ValidationNotification ExactCharactersIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, int exact)
        {
            return source.ExactCharactersIsValid(
                data.GetStructureToValidate(expression),
                exact);
        }

        public static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, object value, int exact)
        {
            return source.ExactCharactersIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, exact);
        }

        public static ValidationNotification ExactCharactersIsValid(
            this ValidationNotification source, IStructureToValidate data, int exact)
        {
            source.CleanLastMessage();
            ExactCharactersIsValidAttribute validation = new ExactCharactersIsValidAttribute(exact);
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
