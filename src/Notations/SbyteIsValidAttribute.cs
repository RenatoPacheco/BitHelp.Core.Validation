using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class SbyteIsValidAttribute : ListIsValidAttribute
    {
        public SbyteIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XByteInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return sbyte.TryParse(input, out _);
        }
    }
}
