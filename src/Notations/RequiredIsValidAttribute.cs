namespace BitHelp.Core.Validation.Notations
{
    public class RequiredIsValidAttribute : ListIsValidAttribute
    {
        public RequiredIsValidAttribute() : base()
        {
            this.ErrorMessageResourceName = nameof(Resources.Resource.XRequerid);
            this.IgnoreNull = false;
        }

        protected override bool Check(object value)
        {
            return !object.Equals(value, null);
        }
    }
}
