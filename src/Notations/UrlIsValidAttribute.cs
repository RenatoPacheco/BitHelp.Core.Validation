using System;
using System.Text.RegularExpressions;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class UrlIsValidAttribute : ListIsValidAttribute
    {
        public UrlIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XUrlInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
