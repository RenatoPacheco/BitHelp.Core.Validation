using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ExactLengthIsValidAttribute : ListIsValidAttribute
    {
        public ExactLengthIsValidAttribute(int exact)
        {
            if (exact < 1)
                throw new ArgumentException("Minimum value is 1", nameof(exact));

            this.Exact = exact;
        }

        public int Exact { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return input.Length == this.Exact;
        }
    }
}
