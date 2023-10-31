using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenTimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public BetweenTimeSpanIsValidAttribute(
            IEnumerable<TimeSpan> options, 
            bool deny = false, CultureInfo cultureInfo = null) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            CultureInfo = cultureInfo;
            Deny = deny;
        }

        IEnumerable<TimeSpan> Options { get; set; } = Array.Empty<TimeSpan>();

        bool Deny { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is TimeSpan check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
                isValueValid = TimeSpan.TryParse(Convert.ToString(value), cultureInfo, out TimeSpan convert);
                contains = Options.Contains(convert);
            }

            return !isValueValid || (Deny ? !contains : contains);
        }
    }
}
