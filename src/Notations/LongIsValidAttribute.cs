﻿using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class LongIsValidAttribute : ListIsValidAttribute
    {
        public LongIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XLongInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return long.TryParse(input, out _);
        }
    }
}
