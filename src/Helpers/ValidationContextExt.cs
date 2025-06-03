using System;
using System.Reflection;
using BitHelp.Core.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Helpers {

    public static class ValidationContextExt {

        public static PropertyInfo GetPropertyInfo(this ValidationContext source, string propertyName) {
            PropertyInfo property = string.IsNullOrWhiteSpace(propertyName)
                ? null : source.ObjectType.GetProperty(propertyName);

            if (object.Equals(property, null)) {
                throw new NullReferenceException(
                    string.Format(Resource.XNotFound, nameof(propertyName)));
            }

            return property;
        }
    }
}
