using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenGuidIsValidAttribute : ListIsValidAttribute
    {
        public BetweenGuidIsValidAttribute(
            IEnumerable<Guid> options, bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
            {
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));
            }

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            Denay = denay;
        }

        private IEnumerable<Guid> Options { get; set; } = Array.Empty<Guid>();

        private bool Denay { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is Guid check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = Guid.TryParse(Convert.ToString(value), out Guid convert);
                contains = Options.Contains(convert);
            }

            return !isValueValid || (Denay ? !contains : contains);
        }
    }
}
