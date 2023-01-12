using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class UintIsValidAttribute : ListIsValidAttribute
    {
        public UintIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XIntInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return uint.TryParse(input, out _);
        }
    }
}
