using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    public class NotEmptyIsValidAttribute : ListIsValidAttribute
    {
        public NotEmptyIsValidAttribute(bool ignoreWithSpace = false) : base()
        {
            ErrorMessageResourceName = nameof(Resource.XNotEmptyInvalid);
            IgnoreWithSpace = ignoreWithSpace;
        }

        public bool IgnoreWithSpace { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return IgnoreWithSpace ? 
                !string.IsNullOrEmpty(input) : !string.IsNullOrWhiteSpace(input);
        }
    }
}
