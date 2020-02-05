using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class MinItensIsValidAttribute : BaseIsValidAttribute
    {
        public MinItensIsValidAttribute(int minimum)
            : base()
        {
            if (minimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(minimum));

            ErrorMessageResourceName = nameof(Resource.XMinItensIsInvalid);

            Minimum = minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum);
        }

        public int Minimum { get; set; }
        
        protected override bool Check(object value)
        {
            IList input = value as IList;
            return (input == null || input.Count == 0) 
                || input.Count >= Minimum;
        }
    }
}
