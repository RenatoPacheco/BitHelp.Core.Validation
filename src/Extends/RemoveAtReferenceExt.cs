using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Helpers;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class RemoveAtReferenceExt
    {
        public static ValidationNotification RemoveAtReference<T, P>(
            this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
        {
            string reference = expression.PropertyPath();
            source.Notifications.RemoveAtReference(reference);

            return source.Notifications;
        }

        public static ValidationNotification RemoveAtReference<T, P>(
            this ValidationNotification source, T data, Expression<Func<T, P>> expression)
        {
            var validate = data.GetStructureToValidate(expression);
            source.RemoveAtReference(validate.Reference);

            return source;
        }
    }
}
