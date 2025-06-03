using System;
using System.Linq;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class RequiredIfOtherIsNullIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification RequiredIfOtherIsNullIsValid<T, P, C>(
            this T source, Expression<Func<T, P>> expression, Expression<Func<T, C>> compare)
            where T : ISelfValidation
        {
            return source.RequiredIfOtherIsNullIsValid(
                source.GetStructureToValidate(expression), source.GetStructureToValidate(compare));
        }

        public static ValidationNotification RequiredIfOtherIsNullIsValid<T>(
            this T source, IStructureToValidate data, IStructureToValidate compare)
            where T : ISelfValidation
        {
            return source.Notifications.RequiredIfOtherIsNullIsValid(data, compare);
        }

        #endregion

        public static ValidationNotification RequiredIfOtherIsNullIsValid<T, P, C>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, Expression<Func<T, C>> compare)
        {
            return source.RequiredIfOtherIsNullIsValid(
                data.GetStructureToValidate(expression), data.GetStructureToValidate(compare));
        }

        public static ValidationNotification RequiredIfOtherIsNullIsValid(
            this ValidationNotification source, IStructureToValidate data, IStructureToValidate compare)
        {
            source.CleanLastMessage();
            if(!source.Messages.Any(x => x.IsTypeError() && x.Reference?.ToLower() == data.Reference?.ToLower()))
            {
                if (object.Equals(compare.Value, null) && object.Equals(data.Value, null))
                {
                    string text = string.Format(Resource.XIsRequiredIfOtherIsNull, data.Display, compare.Display);
                    var message = new ValidationMessage(text, data.Reference);
                    source.SetLastMessage(message, data.Display);
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
