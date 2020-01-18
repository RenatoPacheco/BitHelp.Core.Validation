using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class GuidIsValidAttribute : ListIsValidAttribute
    {
        public GuidIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XGuidInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return Guid.TryParse(input, out _);
        }
    }
}
