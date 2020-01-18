using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BoolIsValidAttribute : ListIsValidAttribute
    {
        public BoolIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XBooleanInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return bool.TryParse(input, out _);
        }
    }
}
