using System;

namespace BitHelp.Core.Validation.Notations
{
    public class NotEmptyIsValidAttribute : ListIsValidAttribute
    {
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return !string.IsNullOrEmpty(input);
        }
    }
}
