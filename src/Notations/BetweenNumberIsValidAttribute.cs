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
        public BetweenNumberIsValidAttribute(IEnumerable<decimal> options) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
        }

        IEnumerable<decimal> Options { get; set; } = Array.Empty<decimal>();

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return decimal.TryParse(input, out decimal compare) && Options.Contains(compare);
        }
    }
}
