using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenStringIsValidAttribute : ListIsValidAttribute
    {
        public BetweenStringIsValidAttribute(IEnumerable<string> options) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
        }

        IEnumerable<string> Options { get; set; } = Array.Empty<string>();

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return Options.Contains(input);
        }
    }
}
