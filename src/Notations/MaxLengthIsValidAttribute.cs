using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MaxLengthIsValidAttribute : ListIsValidAttribute
    {
        public MaxLengthIsValidAttribute(int maximum)
        {
            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            this.Maximum = maximum;
        }

        public int Maximum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length <= this.Maximum;
        }
    }
}
