using BitHelp.Core.Validation.Test.Demo.Scopes;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;

namespace BitHelp.Core.Validation.Test.Demo.Services.Common {

    public abstract class BaseServ
        : ISelfValidation {

        #region Auto ISelfValidation

        protected readonly UserScope<InsertUserCmd> _scpUser;

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
