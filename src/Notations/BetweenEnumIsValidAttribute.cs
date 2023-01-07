using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenEnumIsValidAttribute : ListIsValidAttribute
    {
        public BetweenEnumIsValidAttribute(
            IEnumerable<Enum> options, bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            Denay = denay;
        }

        IEnumerable<Enum> Options { get; set; } = Array.Empty<Enum>();

        bool Denay { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            IEnumerable<string> texts = Options.Select(x => x.ToString());
            bool contains = texts.Contains(input);
            return Denay ? !contains : contains;
        }
    }
}
