using System;
using System.Reflection;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;
using BitHelp.Core.Validation.Helpers;
using System.Globalization;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class ComparePlusTimeSpanIsValidAttribute : ValidationAttribute
    {
        public ComparePlusTimeSpanIsValidAttribute(string otherProperty, string cultureInfo = null)
        {
            ErrorMessageResourceType = typeof(Resource);
            ErrorMessageResourceName = nameof(Resource.XComparePlusInvalid);

            OtherProperty = otherProperty;
            CultureInfo = cultureInfo;
        }

        public string OtherProperty { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public string CultureInfo { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.GetPropertyInfo(OtherProperty);

            CultureInfo cultureInfo = System.Globalization.CultureInfo.CurrentCulture;

            if (CultureInfo != null)
            {
                if (CultureInfo.DoesCultureExist())
                {
                    cultureInfo = new CultureInfo(CultureInfo);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(Resource.XNotValid, nameof(CultureInfo)));
                }
            }

            object otherValue = property.GetValue(validationContext.ObjectInstance, null);

            if (!object.Equals(otherValue, null) && !object.Equals(value, null))
            {
                if (TimeSpan.TryParse(Convert.ToString(value), cultureInfo, out TimeSpan newValue)
                    && TimeSpan.TryParse(Convert.ToString(otherValue), cultureInfo, out TimeSpan newCompare)
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
