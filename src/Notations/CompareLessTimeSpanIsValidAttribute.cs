using System;
using System.Reflection;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class CompareLessTimeSpanIsValidAttribute : ValidationAttribute
    {
        public CompareLessTimeSpanIsValidAttribute(string otherProperty)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException(nameof(otherProperty));
            }

            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XCompareLessInvalid);

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
                if (TimeSpan.TryParse(Convert.ToString(value), out TimeSpan newValue)
                    && TimeSpan.TryParse(Convert.ToString(otherValue), out TimeSpan newCompare)
                    && newValue >= newCompare)
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
