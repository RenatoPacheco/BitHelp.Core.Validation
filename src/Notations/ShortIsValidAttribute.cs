using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ShortIsValidAttribute : ListIsValidAttribute
    {
        public ShortIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XShortInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return short.TryParse(input, out _);
        }
    }
}
