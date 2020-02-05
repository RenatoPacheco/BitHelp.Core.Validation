﻿using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MaxNumberIsValidAttribute : ListIsValidAttribute
    {
        public MaxNumberIsValidAttribute(int maximum)
            : base()
        {
            ErrorMessageResourceName = nameof(Resource.XMaxValueInvalid);

            Maximum = maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Maximum);
        }

        public int Maximum { get; set; }
        
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return int.TryParse(input, out int compare) && compare <= Maximum;
        }
    }
}
