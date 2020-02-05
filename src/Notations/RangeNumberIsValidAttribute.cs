using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeNumberIsValidAttribute : ListIsValidAttribute
    {
        public RangeNumberIsValidAttribute(int minimum, int maximum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            if (maximum < minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanLess, nameof(maximum), nameof(minimum)));

            if (maximum == minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanEqual, nameof(maximum), nameof(minimum)));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XRangeValueInvalid);

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
            string input = Convert.ToString(value);
            return int.TryParse(input, out int number) && number >= this.Minimum && number <= Maximum;
        }
    }
}
