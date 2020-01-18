using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class IntIsValidAttribute : ListIsValidAttribute
    {
        public IntIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XIntInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return int.TryParse(input, out _);
        }
    }
}
