using System;
using System.Reflection;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;
using BitHelp.Core.Validation.Helpers;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredIfOtherNotNullIsValidAttribute : ValidationAttribute
    {
        public RequiredIfOtherNotNullIsValidAttribute(string otherProperty)
        {
            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XRequired);

            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.GetPropertyInfo(OtherProperty);

            object otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if (object.Equals(otherValue, null) || !object.Equals(value, null))
                return null;

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
