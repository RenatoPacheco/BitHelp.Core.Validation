using System;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Notations
{
    public abstract class BaseIsValidAttribute : ValidationAttribute
    {
        public BaseIsValidAttribute()
        {
            this.ErrorMessageResourceType = typeof(Resources.Resource);
            this.ErrorMessageResourceName = nameof(Resources.Resource.XNotValid);
        }

        protected bool IgnoreEmpty { get; set; } = false;

        protected bool IgnoreNull { get; set; } = true;

        protected abstract bool Check(object value);

        public override bool IsValid(object value)
        {
            if (!object.Equals(value, null))
            {
                string input = Convert.ToString(value ?? string.Empty);
                return (this.IgnoreEmpty && string.IsNullOrEmpty(input)) || this.Check(value);
            }
            return this.IgnoreNull;
        }
    }
}
