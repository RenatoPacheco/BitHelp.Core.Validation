using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeCharactersIsValidAttribute : ListIsValidAttribute
    {
        public RangeCharactersIsValidAttribute(int minimum, int maximum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XRangeCharactersInvalid);

            this.Minimum = minimum;
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
            return input.Length >= this.Minimum && input.Length <= Maximum;
        }
    }
}
