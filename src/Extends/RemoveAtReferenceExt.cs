using BitHelp.Core.Extend;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class RemoveAtReferenceExt
    {
        public static ValidationNotification RemoveAtReference<T, P>(
            this ValidationNotification source, Expression<Func<T, P>> expression)
        {
            string reference = expression.PropertyTrail();
            source.RemoveAtReference(reference);

            return source;
        }
    }
}
