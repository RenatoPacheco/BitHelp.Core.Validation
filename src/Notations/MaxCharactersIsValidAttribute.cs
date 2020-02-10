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
                throw new ArgumentException(string.Format(Resource.MinimumValidIs, "1"), nameof(maximum));

            ErrorMessageResourceName = nameof(Resource.XMaxCharactersInvalid);

            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Maximum);
        }

        public int Maximum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length <= Maximum;
        }
    }
}
