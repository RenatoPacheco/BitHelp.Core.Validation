using BitHelp.Core.Extend;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Test.Extend
{
    public static class ClassExtend
    {
        public static string GetDisplayName<TClass>(this TClass source, Expression<Func<TClass, object>> expression)
        {
            return expression.PropertyDisplay();
        }
    }
}
