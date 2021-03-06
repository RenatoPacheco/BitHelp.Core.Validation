﻿using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RangeNumberIsValidAttribute : ListIsValidAttribute
    {
        public RangeNumberIsValidAttribute(decimal minimum, decimal maximum)
            : base()
        {
            if (maximum < minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanLess, nameof(maximum), nameof(minimum)));

            if (maximum == minimum)
                throw new ArgumentException(string.Format(Resource.XNoValueCanEqual, nameof(maximum), nameof(minimum)));

            ErrorMessageResourceName = nameof(Resource.XRangeValueInvalid);

            Minimum = minimum;
            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum, Maximum);
        }

        public decimal Minimum { get; set; }

        public decimal Maximum { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return decimal.TryParse(input, out decimal compare) && compare >= Minimum && compare <= Maximum;
        }
    }
}
