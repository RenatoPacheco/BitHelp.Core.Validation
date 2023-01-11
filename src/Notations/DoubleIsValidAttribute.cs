using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class DoubleIsValidAttribute : ListIsValidAttribute
    {
        public DoubleIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XDoubleInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return double.TryParse(input, out _);
        }
    }
}
