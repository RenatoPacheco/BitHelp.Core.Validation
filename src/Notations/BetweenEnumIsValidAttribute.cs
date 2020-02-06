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
        public BetweenEnumIsValidAttribute(IEnumerable<Enum> options) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
        }

        IEnumerable<Enum> Options { get; set; } = new Enum[] { };

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            IEnumerable<string> texts = this.Options.Select(x => x.ToString());
            return texts.Contains(input);
        }
    }
}
