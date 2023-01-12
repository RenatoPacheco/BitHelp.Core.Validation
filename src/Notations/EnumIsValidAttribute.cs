using System;
using BitHelp.Core.Validation.Helpers;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class EnumIsValidAttribute : ListIsValidAttribute
    {
        public EnumIsValidAttribute(Type type, bool ignoreCase = false)
        {
            if (!type?.IsEnum ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XNotValid, nameof(type)), nameof(type));

            Type = type;
            IgnoreCase = ignoreCase;
        }

        public Type Type { get; set; }

        public bool IgnoreCase { get; set; }

        protected override bool Check(object value)
        {
            return TryParse.ToEnum(Type, value, IgnoreCase, out _);
        }
    }
}
