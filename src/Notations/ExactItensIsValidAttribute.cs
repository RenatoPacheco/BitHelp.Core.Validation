using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ExactItensIsValidAttribute : BaseIsValidAttribute
    {
        public ExactItensIsValidAttribute(int exact)
            : base()
        {
            if (exact < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(exact));

            ErrorMessageResourceName = nameof(Resource.XExactItensIsInvalid);

            Exact = exact;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Exact);
        }

        public int Exact { get; set; }
        
        protected override bool Check(object value)
        {
            IList input = value as IList;
            return (input == null || input.Count == 0) 
                || input.Count == Exact;
        }
    }
}
