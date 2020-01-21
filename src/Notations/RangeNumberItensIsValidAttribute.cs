using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeNumberItensIsValidAttribute : BaseIsValidAttribute
    {
        public RangeNumberItensIsValidAttribute(int minimum, int maximum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XRangeNumerItensInvalid);

            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Minimum, this.Maximum);
        }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        protected override bool Check(object value)
        {
            IList input = value as IList;
            return input == null || (input.Count >= this.Minimum && input.Count <= this.Maximum);
        }
    }
}
