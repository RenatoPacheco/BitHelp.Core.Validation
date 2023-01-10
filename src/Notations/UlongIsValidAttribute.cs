using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class UlongIsValidAttribute : ListIsValidAttribute
    {
        public UlongIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XLongInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return ulong.TryParse(input, out _);
        }
    }
}
