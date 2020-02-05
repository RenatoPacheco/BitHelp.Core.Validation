using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinTimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public MinTimeSpanIsValidAttribute(TimeSpan minimum)
            : base()
        {
            ErrorMessageResourceName = nameof(Resource.XMinCharactersInvalid);

            Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public TimeSpan Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return TimeSpan.TryParse(input, out TimeSpan compare) && compare >= Minimum;
        }
    }
}
