﻿using System;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = true)]
    public class DenyRegexIsValidAttribute : ListIsValidAttribute
    {
        public DenyRegexIsValidAttribute(string pattern, RegexOptions options = RegexOptions.None)
            :base()
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException(string.Format(Resource.XNotEmptyInvalid, nameof(pattern)), nameof(pattern));

            Pattern = pattern;
            Options = options;
        }

        public string Pattern { get; set; }

        public RegexOptions Options { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return !Regex.IsMatch(input, Pattern, Options);
        }
    }
}
