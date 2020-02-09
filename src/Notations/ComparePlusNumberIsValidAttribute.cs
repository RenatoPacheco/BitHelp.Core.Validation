using System;
using System.Reflection;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ComparePlusNumberIsValidAttribute : ValidationAttribute
    {
        public ComparePlusNumberIsValidAttribute(string otherProperty)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException(nameof(otherProperty));
            }

            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XComparePlusInvalid);

            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (object.Equals(property, null))
            {
                throw new ArgumentException(Resource.NotValid, nameof(OtherProperty));
            }

            object otherValue = property.GetValue(validationContext.ObjectInstance, null);

            if (!object.Equals(otherValue, null) && !object.Equals(value, null))
            {
                if (decimal.TryParse(Convert.ToString(value), out decimal newValue)
                    && decimal.TryParse(Convert.ToString(otherValue), out decimal newCompare)
                    && newValue <= newCompare)
                {
                    string name = validationContext.DisplayName;
                    string nameCompare = property.PropertyDisplay();
                    return new ValidationResult(string.Format(ErrorMessageString, name, nameCompare));
                }
            }

            return null;
        }
    }
}
