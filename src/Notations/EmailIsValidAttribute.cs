using System;
using System.Text.RegularExpressions;

namespace BitHelp.Core.Validation.Notations
{
    /// <summary>
    /// Validate Email, the pattern to rule, was copied from Angular 6
    /// </summary>
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class EmailIsValidAttribute : ListIsValidAttribute
    {
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            string pattern = @"^(?=.{1,254}$)(?=.{1,64}@)[-!#$%&'*+/0-9=?A-Z^_`a-z{|}~]+(\.[-!#$%&'*+/0-9=?A-Z^_`a-z{|}~]+)*@[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?(\.[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?)*$";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
