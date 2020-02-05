using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinNumberIsValidAttribute : ListIsValidAttribute
    {
        public MinNumberIsValidAttribute(decimal minimum)
            : base()
        {
            ErrorMessageResourceName = nameof(Resource.XMinValueInvalid);

            Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public decimal Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return decimal.TryParse(input, out decimal compare) && compare >= Minimum;
        }
    }
}
