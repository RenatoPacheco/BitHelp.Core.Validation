using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class EnumIsValidAttribute : ListIsValidAttribute
    {
        public EnumIsValidAttribute(Type type)
        {
            if (!type?.IsEnum ?? true)
                throw new ArgumentException(
                    string.Format(Resource.XIntInvalid, nameof(type)), nameof(type));

            Type = type;
        }

        public Type Type { get; set; }

        protected override bool Check(object value)
        {
            return Enum.IsDefined(Type, value);
        }
    }
}
