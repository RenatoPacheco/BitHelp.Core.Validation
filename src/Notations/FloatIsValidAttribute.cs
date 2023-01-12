using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class FloatIsValidAttribute : ListIsValidAttribute
    {
        public FloatIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XDecimalInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return float.TryParse(input, out _);
        }
    }
}
