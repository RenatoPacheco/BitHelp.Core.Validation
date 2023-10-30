using BitHelp.Core.Validation.Resources;
using System;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class TimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public TimeSpanIsValidAttribute(CultureInfo cultureInfo = null) : base()
        {
            ErrorMessageResourceName = nameof(Resource.XTimeSpanInvalid);

            CultureInfo = cultureInfo;
        }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
            return TimeSpan.TryParse(input, cultureInfo, out _);
        }
    }
}
