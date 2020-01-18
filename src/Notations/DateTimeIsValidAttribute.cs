using System;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class DateTimeIsValidAttribute : ListIsValidAttribute
    {
        public DateTimeIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XDateTimeInvalid);
        }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return DateTime.TryParse(input, this.CultureInfo ?? CultureInfo.CurrentCulture, DateTimeStyles.None, out _);
        }
    }
}
