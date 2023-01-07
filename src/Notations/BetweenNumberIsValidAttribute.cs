using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenNumberIsValidAttribute : ListIsValidAttribute
    {
        public BetweenNumberIsValidAttribute(
            IEnumerable<decimal> options, bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            Denay = denay;
        }

        IEnumerable<decimal> Options { get; set; } = Array.Empty<decimal>();

        bool Denay { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            bool isNumber = decimal.TryParse(input, out decimal compare);
            bool contains = Options.Contains(compare);
            return isNumber && (Denay ? !contains : contains);
        }
    }
}
