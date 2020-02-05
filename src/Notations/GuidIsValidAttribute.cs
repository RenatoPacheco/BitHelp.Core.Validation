using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class GuidIsValidAttribute : ListIsValidAttribute
    {
        public GuidIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XGuidInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return Guid.TryParse(input, out _);
        }
    }
}
