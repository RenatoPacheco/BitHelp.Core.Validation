using BitHelp.Core.Validation.Resources;
using System;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinTimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public MinTimeSpanIsValidAttribute(TimeSpan minimum, CultureInfo cultureInfo = null)
            : base()
        {
            ErrorMessageResourceName = nameof(Resource.XMinValueInvalid);

            Minimum = minimum;
            CultureInfo = cultureInfo;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public TimeSpan Minimum { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
            return TimeSpan.TryParse(input, cultureInfo, out TimeSpan compare) && compare >= Minimum;
        }
    }
}
