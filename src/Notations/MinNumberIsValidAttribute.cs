using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinNumberIsValidAttribute : ListIsValidAttribute
    {
        public MinNumberIsValidAttribute(int minimum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            this.Minimum = minimum;
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return int.TryParse(input, out int number) && number >= this.Minimum;
        }
    }
}
