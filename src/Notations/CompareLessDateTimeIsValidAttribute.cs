using System;
using System.Reflection;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class CompareLessDateTimeIsValidAttribute : ValidationAttribute
    {
        public CompareLessDateTimeIsValidAttribute(string otherProperty, string cultureInfo = null)
        {
            if (string.IsNullOrWhiteSpace(otherProperty))
            {
                throw new ArgumentException(
                    Resource.ValueCannotBeNullOrEmpty, nameof(otherProperty));
            }

            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XCompareLessInvalid);

            OtherProperty = otherProperty;
            if(!(cultureInfo is null))
            {
                CultureInfo = new CultureInfo(cultureInfo);
            }
        }

        public string OtherProperty { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (object.Equals(property, null))
            {
                throw new Exception(string.Format(Resource.XNotFound, nameof(OtherProperty)));
            }

            CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
            object otherValue = property.GetValue(validationContext.ObjectInstance, null);

            if (!object.Equals(otherValue, null) && !object.Equals(value, null))
            {
                if (DateTime.TryParse(Convert.ToString(value), cultureInfo, DateTimeStyles.None, out DateTime newValue)
                    && DateTime.TryParse(Convert.ToString(otherValue), cultureInfo, DateTimeStyles.None, out DateTime newCompare)
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
