namespace BitHelp.Core.Validation.Notations
{
    public class RequiredIsValidAttribute : ListIsValidAttribute
    {
        public RequiredIsValidAttribute()
        {
            this.IgnoreNull = false;
        }

        protected override bool Check(object value)
        {
            return !object.Equals(value, null);
        }
    }
}
