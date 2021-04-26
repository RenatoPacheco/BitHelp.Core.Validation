using BitHelp.Core.Extend;
using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation
{
    public struct StructureToValidate : IStructureToValidate
    {
        public object Value { get; set; }

        public string Display { get; set; }

        public string Reference { get; set; }
    }
}
