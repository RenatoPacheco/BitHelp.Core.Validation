using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RequiredIfOtherNotNullIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RequiredIfOtherNotNullIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, object compare)
            where T : ISelfValidation
        {
            return source.RequiredIfOtherNotNullIsValid(
                source.GetStructureToValidate(expression), compare);
        }

        public static ValidationNotification RequiredIfOtherNotNullIsValid<T>(
            this T source, object value, object compare)
            where T : ISelfValidation
        {
            return source.RequiredIfOtherNotNullIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, compare);
        }

        public static ValidationNotification RequiredIfOtherNotNullIsValid<T>(
            this T source, IStructureToValidate data, object compare)
            where T : ISelfValidation
        {
            return source.Notifications.RequiredIfOtherNotNullIsValid(data, compare);
        }

        #endregion

        public static ValidationNotification RequiredIfOtherNotNullIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, object compare)
        {
            return source.RequiredIfOtherNotNullIsValid(
                data.GetStructureToValidate(expression), compare);
        }

        public static ValidationNotification RequiredIfOtherNotNullIsValid(
            this ValidationNotification source, object value, object compare)
        {
            return source.RequiredIfOtherNotNullIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, compare);
        }

        [Obsolete("Use RequiredIfOtherNotNullIsValid(IStructureToValidate data, object compare)")]
        private static ValidationNotification RequiredIfOtherNotNullIsValid(
            this ValidationNotification source, object value, string display, string reference, object compare)
        {
            return source.RequiredIfOtherNotNullIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, compare);
        }

        public static ValidationNotification RequiredIfOtherNotNullIsValid(
            this ValidationNotification source, IStructureToValidate data, object compare)
        {
            source.CleanLastMessage();
            if(!source.Messages.Any(x => x.IsTypeError() && x.Reference?.ToLower() == data.Reference?.ToLower()))
            {
                if (!object.Equals(compare, null) && object.Equals(data.Value, null))
                {
                    string text = string.Format(Resource.XRequired, data.Display);
                    var message = new ValidationMessage(text, data.Reference);
                    source.SetLastMessage(message, data.Display);
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
