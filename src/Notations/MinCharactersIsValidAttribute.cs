using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinCharactersIsValidAttribute : ListIsValidAttribute
    {
        public MinCharactersIsValidAttribute(int minimum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XMinCharactersInvalid);

            this.Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Minimum);
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length >= this.Minimum;
        }
    }
}
