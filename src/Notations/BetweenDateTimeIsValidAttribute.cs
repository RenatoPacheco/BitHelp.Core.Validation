using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenDateTimeIsValidAttribute : ListIsValidAttribute
    {
        public BetweenDateTimeIsValidAttribute(
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            CultureInfo = cultureInfo;
            Denay = denay;
        }

        IEnumerable<DateTime> Options { get; set; } = Array.Empty<DateTime>();

        bool Denay { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid;
            bool contains;
            string[] options = Options.Select(x => ToString(x)).ToArray();

            if (value is DateTime check)
            {
                isValueValid = true;
                contains = options.Contains(ToString(check));
            }
            else
            {
                isValueValid = TryParse(Convert.ToString(value), out DateTime convert);
                contains = options.Contains(ToString(convert));
            }

            return isValueValid && (Denay ? !contains : contains);
        }

        private bool TryParse(string input, out DateTime output)
        {
            return DateTime.TryParse(input,
                CultureInfo ?? CultureInfo.CurrentCulture,
                DateTimeStyles.None, out output);
        }

        private string ToString(DateTime input)
        {
            return input.ToString(
                CultureInfo ?? CultureInfo.CurrentCulture);
        }
    }
}
