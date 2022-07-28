using System;
using BitHelp.Core.Extend;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Helpers
{
    public static class ObjectExtend
    {
        public static StructureToValidate GetStructureToValidate<T, P>(this T source, Expression<Func<T, P>> expression)
        {
            return new StructureToValidate
            {
                Reference = expression.PropertyPath(),
                Value = expression.Compile().DynamicInvoke(source),
                Display = expression.PropertyDisplay()
            };
        }
    }
}
