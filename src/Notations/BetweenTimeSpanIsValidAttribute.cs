using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenTimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public BetweenTimeSpanIsValidAttribute(
            IEnumerable<TimeSpan> options, bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            Denay = denay;
        }

        IEnumerable<TimeSpan> Options { get; set; } = Array.Empty<TimeSpan>();

        bool Denay { get; set; }

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
                isValueValid = TimeSpan.TryParse(Convert.ToString(value), out TimeSpan convert);
                contains = Options.Contains(convert);
            }

            return !isValueValid || (Denay ? !contains : contains);
        }
    }
}
