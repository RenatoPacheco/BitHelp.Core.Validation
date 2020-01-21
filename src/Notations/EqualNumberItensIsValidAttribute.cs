using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class EqualNumberItensIsValidAttribute : BaseIsValidAttribute
    {
        public EqualNumberItensIsValidAttribute(int equalimum)
            : base()
        {
            if (equalimum < 1)
                throw new ArgumentException(string.Format(Resource.MinimumValieIs, "1"), nameof(equalimum));

            this.ErrorMessageResourceName = nameof(Resources.Resource.XEqualNumberItensIsInvalid);

            this.Equal = equalimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Equal);
        }

        public int Equal { get; set; }
        
        protected override bool Check(object value)
        {
            IList input = value as IList;
            return input == null || input.Count == this.Equal;
        }
    }
}
