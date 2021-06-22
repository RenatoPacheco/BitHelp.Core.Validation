using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    public class NotNullOrEmptyIsValidAttribute : ListIsValidAttribute
    {
        public NotNullOrEmptyIsValidAttribute(bool ignoreWithSpace = false) : base()
        {
            ErrorMessageResourceName = nameof(Resource.XNullOrEmpty);
            IgnoreWithSpace = ignoreWithSpace;
            IgnoreNull = false;
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
