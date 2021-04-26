namespace BitHelp.Core.Validation
{
    public interface IStructureToValidate
    {
        object Value { get; }

        string Display { get; }

        string Reference { get; }
    }
}
