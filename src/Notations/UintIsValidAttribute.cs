using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Field, AllowMultiple = false)]
    public class UintIsValidAttribute : ListIsValidAttribute
    {
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return uint.TryParse(input, out _);
        }
    }
}
