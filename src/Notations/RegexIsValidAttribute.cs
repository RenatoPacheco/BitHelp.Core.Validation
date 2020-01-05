using System;
using System.Text.RegularExpressions;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = true)]
    public class RegexIsValidAttribute : ListIsValidAttribute
    {
        public RegexIsValidAttribute(string pattern, RegexOptions options = RegexOptions.None)
        {
            this.Pattern = pattern;
            this.Options = options;
        }

        public string Pattern { get; set; }

        public RegexOptions Options { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return Regex.IsMatch(input, this.Pattern, this.Options);
        }
    }
}
