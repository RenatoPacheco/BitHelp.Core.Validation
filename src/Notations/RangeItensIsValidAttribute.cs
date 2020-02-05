using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeItensIsValidAttribute : BaseIsValidAttribute
    {
        public RangeItensIsValidAttribute(int minimum, int maximum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            if (maximum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(maximum));

            if (maximum < minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanLess, nameof(maximum), nameof(minimum)));

            if (maximum == minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanEqual, nameof(maximum), nameof(minimum)));

            ErrorMessageResourceName = nameof(Resource.XRangeItensInvalid);

            Minimum = minimum;
            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum, Maximum);
        }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        protected override bool Check(object value)
        {
            IList input = value as IList;
            return (input == null || input.Count == 0) 
                || (input.Count >= Minimum && input.Count <= Maximum);
        }
    }
}
