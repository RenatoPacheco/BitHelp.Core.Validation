using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MaxItensIsValidAttribute : BaseIsValidAttribute
    {
        public MaxItensIsValidAttribute(int maximum)
            : base()
        {
            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            ErrorMessageResourceName = nameof(Resource.XMaxItensIsInvalid);

            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Maximum);
        }

        public int Maximum { get; set; }
        
        protected override bool Check(object value)
        {
            IList input = value as IList;
            return (input == null || input.Count == 0) 
                || input.Count <= Maximum;
        }
    }
}
