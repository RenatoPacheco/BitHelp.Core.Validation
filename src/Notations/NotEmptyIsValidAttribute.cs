using System;

namespace BitHelp.Core.Validation.Notations
{
    public class NotEmptyIsValidAttribute : ListIsValidAttribute
    {
        public NotEmptyIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XNotEmptyInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return !string.IsNullOrEmpty(input);
        }
    }
}
