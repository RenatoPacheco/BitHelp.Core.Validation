using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class DoubleIsValidAttribute : ListIsValidAttribute
    {
        public DoubleIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XDoubleInvalid);
        }


        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return double.TryParse(input, out _);
        }
    }
}
