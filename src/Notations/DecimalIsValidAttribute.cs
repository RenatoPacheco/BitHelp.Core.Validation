using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class DecimalIsValidAttribute : ListIsValidAttribute
    {
        public DecimalIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XDecimalInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return decimal.TryParse(input, out _);
        }
    }
}
