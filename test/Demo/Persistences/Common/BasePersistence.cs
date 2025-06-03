namespace BitHelp.Core.Validation.Test.Demo.Persistences.Common {

    public abstract class BasePersistence
        : ISelfValidation {

        #region Auto ISelfValidation

        public ValidationNotification Notifications { get; protected set; } = new();

        public bool IsValid(ISelfValidation validation) {
            Notifications.Add(validation);
            return validation.IsValid();
        }

        public bool IsValid() {
            return Notifications.IsValid();
        }

        #endregion
    }
}
