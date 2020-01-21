using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinNumberItensIsValidAttribute : BaseIsValidAttribute
    {
        public MinNumberItensIsValidAttribute(int minimum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XMinNumberItensIsInvalid);

            this.Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Minimum);
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            IList input = value as IList;
            return input == null || input.Count >= this.Minimum;
        }
    }
}
