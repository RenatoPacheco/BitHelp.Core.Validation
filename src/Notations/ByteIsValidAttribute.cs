using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ByteIsValidAttribute : ListIsValidAttribute
    {
        public ByteIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XByteInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return byte.TryParse(input, out _);
        }
    }
}
