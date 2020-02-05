using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenDateTimeIsValidAttribute : ListIsValidAttribute
    {
        public BetweenDateTimeIsValidAttribute(IEnumerable<DateTime> options, CultureInfo cultureInfo = null) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options.Select(x => DateTime.Parse(x.ToString()));
            CultureInfo = cultureInfo;
        }

        IEnumerable<DateTime> Options { get; set; } = new DateTime[] { };

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
            return DateTime.TryParse(input, cultureInfo, DateTimeStyles.None, out DateTime compare) && Options.Contains(compare);
        }
    }
}
