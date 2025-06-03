namespace BitHelp.Core.Validation {

    public interface ISelfValidation {

        bool IsValid();

        ValidationNotification Notifications { get; }
    }
}
