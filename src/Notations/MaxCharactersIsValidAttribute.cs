using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MaxCharactersIsValidAttribute : ListIsValidAttribute
    {
        public MaxCharactersIsValidAttribute(int maximum)
            : base()
        {
            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XMaxCharactersInvalid);

            this.Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Maximum);
        }

        public int Maximum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length <= this.Maximum;
        }
    }
}
