using BitHelp.Core.Validation.Resources;
using System;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class TimeSpanIsValidAttribute : ListIsValidAttribute
    {
        public TimeSpanIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XTimeSpanInvalid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return TimeSpan.TryParse(input, out _);
        }
    }
}
