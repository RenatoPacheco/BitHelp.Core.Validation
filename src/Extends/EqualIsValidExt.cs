using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Helpers;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification EqualIsValid<T, P>(
            this T source, Expression<Func<T, P>> expression, object compare)
            where T : ISelfValidation
        {
            return source.EqualIsValid(
                source.GetStructureToValidate(expression),
                compare);
        }

        public static ValidationNotification EqualIsValid<T>(
            this T source, object value, object compare)
            where T : ISelfValidation
        {
            return source.EqualIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, compare);
        }

        public static ValidationNotification EqualIsValid<T>(
            this T source, IStructureToValidate data, object compare)
            where T : ISelfValidation
        {
            return source.Notifications.EqualIsValid(data, compare);
        }

        #endregion

        public static ValidationNotification EqualIsValid<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression, object compare)
        {
            return source.EqualIsValid(
                data.GetStructureToValidate(expression),
                compare);
        }

        public static ValidationNotification EqualIsValid(
            this ValidationNotification source, object value, object compare)
        {
            return source.EqualIsValid(new StructureToValidate
            {
                Value = value,
                Display = Resource.DisplayValue,
                Reference = null
            }, compare);
        }

        [Obsolete("Use EqualIsValid(IStructureToValidate data, object compare)")]
        private static ValidationNotification EqualIsValid(
            this ValidationNotification source, object value, string display, string reference, object compare)
        {
            return source.EqualIsValid(new StructureToValidate
            {
                Value = value,
                Display = display,
                Reference = reference
            }, compare);
        }

        public static ValidationNotification EqualIsValid(
            this ValidationNotification source, IStructureToValidate data, object compare)
        {
            source.CleanLastMessage();
            if(data.Value != null && compare != null)
            {
                string valueCheck = Convert.ToString(data.Value);
                string compareCheck = Convert.ToString(compare);
                if (valueCheck != compareCheck)
                {
                    string text = string.Format(Resource.XConfirmedInvalid, data.Display);
                    var message = new ValidationMessage(text, data.Reference);
                    source.SetLastMessage(message, data.Display);
                    source.Add(message);
                }
            }
            return source;
        }
    }
}
