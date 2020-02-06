using System;
using System.Reflection;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredIfOtherNotNullIsValidAttribute : ValidationAttribute
    {
        public RequiredIfOtherNotNullIsValidAttribute(string otherProperty)
        {
            if (otherProperty == null)
                throw new ArgumentNullException(nameof(otherProperty));

            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XRequerid);

            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (object.Equals(property, null))
                throw new ArgumentException(Resource.NotValid, nameof(OtherProperty));

            object otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if (object.Equals(otherValue, null) || !object.Equals(value, null))
                return null;

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
