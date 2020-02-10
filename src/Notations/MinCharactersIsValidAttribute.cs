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
                throw new ArgumentException(string.Format(Resource.MinimumValidIs, "1"), nameof(minimum));

            ErrorMessageResourceName = nameof(Resource.XMinCharactersInvalid);

            Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length >= Minimum;
        }
    }
}
