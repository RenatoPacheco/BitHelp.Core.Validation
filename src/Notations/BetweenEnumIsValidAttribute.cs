using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;
using BitHelp.Core.Validation.Helpers;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenEnumIsValidAttribute : ListIsValidAttribute
    {
        public BetweenEnumIsValidAttribute(
            Type type, IEnumerable<Enum> options, 
            bool ignoreCase = false, bool denay = false) : base()
        {
            if (!type?.IsEnum ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XNotValid, nameof(type)), nameof(type));

            if (!options?.Any() ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            if (options.Any(x => x.GetType() != type))
                throw new ArgumentException(
                    string.Format(Resource.XNotValid, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Type = type;
            Options = options;
            IgnoreCase = ignoreCase;
            Denay = denay;
        }

        IEnumerable<Enum> Options { get; set; } = Array.Empty<Enum>();

        Type Type { get; set; }

        bool IgnoreCase { get; set; }

        bool Denay { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid = TryParse.ToEnum(Type, value, IgnoreCase, out object convert);
            bool contains = Options.Contains(convert);

            return !isValueValid || (Denay ? !contains : contains);
        }
    }
}
