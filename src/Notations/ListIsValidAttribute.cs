using System.Collections;

namespace BitHelp.Core.Validation.Notations
{
    /// <summary>
    /// Allows you to validate each item in a list or a single item.
    /// </summary>
    public abstract class ListIsValidAttribute : BaseIsValidAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = IgnoreNull;
            if (value is IEnumerable && !(value is string))
            {
                var list = value as IEnumerable;
                foreach (var item in list)
                {
                    result = !object.Equals(item, null) && base.IsValid(item);
                    if (!result)
                        break;
                }
            }
            else
            {
                result = base.IsValid(value);
            }
            return result;
        }
    }
}
