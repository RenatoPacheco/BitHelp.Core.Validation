using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinLengthIsValidAttribute : ListIsValidAttribute
    {
        public MinLengthIsValidAttribute(int minimum)
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            this.Minimum = minimum;
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length >= this.Minimum;
        }
    }
}
