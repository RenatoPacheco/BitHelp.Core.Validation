using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    public class RequiredIsValidAttribute : ListIsValidAttribute
    {
        public RequiredIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XRequired);
            IgnoreNull = false;
        }

        protected override bool Check(object value)
        {
            return !object.Equals(value, null);
        }
    }
}
