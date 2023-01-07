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
            string input = Convert.ToString(value);
            bool isNumber = TimeSpan.TryParse(input, out TimeSpan compare);
            bool contains = Options.Contains(compare);
            return isNumber && (Denay ? !contains : contains);
        }
    }
}
