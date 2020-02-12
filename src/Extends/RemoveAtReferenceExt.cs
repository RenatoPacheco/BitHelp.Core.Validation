using BitHelp.Core.Extend;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class RemoveAtReferenceExt
    {
        public static ValidationNotification RemoveAtReference<TClass>(
            this ValidationNotification source, Expression<Func<TClass, object>> expression)
        {
            string reference = expression.PropertyTrail();
            source.RemoveAtReference(reference);

            return source;
        }
    }
}
