using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ExactCharactersIsValidAttribute : ListIsValidAttribute
    {
        public ExactCharactersIsValidAttribute(int exact)
        {
            if (exact < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValidIs, "1"), nameof(exact));

            ErrorMessageResourceName = nameof(Resource.XExactCharactersInvalid);

            Exact = exact;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Exact);
        }

        public int Exact { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length == Exact;
        }
    }
}
