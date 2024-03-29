﻿using System;
using System.Linq;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenStringIsValidAttribute : ListIsValidAttribute
    {
        public BetweenStringIsValidAttribute(
            IEnumerable<string> options, bool deny = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options;
            Deny = deny;
        }

        IEnumerable<string> Options { get; set; } = Array.Empty<string>();

        bool Deny { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            bool contains = Options.Contains(input);
            return Deny ? !contains : contains;
        }
    }
}
