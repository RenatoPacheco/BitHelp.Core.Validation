using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class IntIsValidAttribute : ListIsValidAttribute
    {
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return int.TryParse(input, out _);
        }
    }
}
