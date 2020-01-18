namespace BitHelp.Core.Validation.Test.Resources
{
    public class LevelValues
    {
        public string Public { get; set; }

        public string Protected { get; protected set; }

        public string ProtectedInternal { get; protected internal set; }

        public string Private { get; private set; }

        public string ProtectedPrivate { get; protected private set; }
    }
}
