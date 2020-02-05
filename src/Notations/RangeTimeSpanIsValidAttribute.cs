using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeTimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public RangeTimeSpanIsValidAttribute(TimeSpan minimum, TimeSpan maximum)
            : base()
        {
            if (maximum < minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanLess, nameof(maximum), nameof(minimum)));

            if (maximum == minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanEqual, nameof(maximum), nameof(minimum)));

            ErrorMessageResourceName = nameof(Resource.XRangeValueInvalid);

            Minimum = minimum;
            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum, Maximum);
        }

        public TimeSpan Minimum { get; set; }

        public TimeSpan Maximum { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return TimeSpan.TryParse(input, out TimeSpan compare) && compare >= Minimum && compare <= Maximum;
        }
    }
}
