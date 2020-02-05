using System;

namespace BitHelp.Core.Validation.Notations
{
    public class NotEmptyIsValidAttribute : ListIsValidAttribute
    {
        public NotEmptyIsValidAttribute(bool ignoreWithSpace = false) : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XNotEmptyInvalid);
            this.IgnoreWithSpace = ignoreWithSpace;
        }

        public bool IgnoreWithSpace { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return this.IgnoreWithSpace ? 
                !string.IsNullOrEmpty(input) : !string.IsNullOrWhiteSpace(input);
        }
    }
}
