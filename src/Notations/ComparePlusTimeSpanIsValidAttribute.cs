using System;
using System.Reflection;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;
using BitHelp.Core.Validation.Helpers;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ComparePlusTimeSpanIsValidAttribute : ValidationAttribute
    {
        public ComparePlusTimeSpanIsValidAttribute(string otherProperty)
        {
            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XComparePlusInvalid);

            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.GetPropertyInfo(OtherProperty);

            object otherValue = property.GetValue(validationContext.ObjectInstance, null);

            if (!object.Equals(otherValue, null) && !object.Equals(value, null))
            {
                if (TimeSpan.TryParse(Convert.ToString(value), out TimeSpan newValue)
                    && TimeSpan.TryParse(Convert.ToString(otherValue), out TimeSpan newCompare)
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
