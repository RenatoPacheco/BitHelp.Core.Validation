using BitHelp.Core.Validation.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Notations
{
    public abstract class BaseIsValidAttribute : ValidationAttribute
    {
        public BaseIsValidAttribute()
        {
            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XNotValid);
        }

        protected bool IgnoreEmpty { get; set; } = false;

        protected bool IgnoreNull { get; set; } = true;

        protected abstract bool Check(object value);

        public override bool IsValid(object value)
        {
            if (!object.Equals(value, null))
            {
                string input = Convert.ToString(value ?? string.Empty);
                return (IgnoreEmpty && string.IsNullOrEmpty(input)) || Check(value);
            }
            return IgnoreNull;
        }
    }
}
