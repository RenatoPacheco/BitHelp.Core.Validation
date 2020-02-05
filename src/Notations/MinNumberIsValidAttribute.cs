using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinNumberIsValidAttribute : ListIsValidAttribute
    {
        public MinNumberIsValidAttribute(long minimum)
            : base()
        {
            ErrorMessageResourceName = nameof(Resource.XMinValueInvalid);

            Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public long Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return long.TryParse(input, out long compare) && compare >= Minimum;
        }
    }
}
