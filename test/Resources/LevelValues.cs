namespace BitHelp.Core.Validation.Test.Resources
{
    public class LevelValues
    {
        public string Public { get; set; }

        public string Protected { get; protected set; }

        public string Internal { get; protected internal set; }

        public string Private { get; protected private set; }
    }
}
