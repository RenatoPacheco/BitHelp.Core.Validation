using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class EnumIsValidAttribute : ListIsValidAttribute
    {
        public EnumIsValidAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }

        protected override bool Check(object value)
        {
            return Enum.IsDefined(this.Type, value);
        }
    }
}
