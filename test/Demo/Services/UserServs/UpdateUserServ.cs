using BitHelp.Core.Validation.Test.Demo.Entities;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;
using BitHelp.Core.Validation.Test.Demo.Persistences.UserPersistences;

namespace BitHelp.Core.Validation.Test.Demo.Services.UserServs {
    public class UpdateUserServ
        : Common.BaseServ {

        public User Execute(UpdateUserCmd command) {
            Notifications.Clear();
            User result = null;

            if (IsValid(command)) {

                var getUser = new GetUserPersistence();
                result = getUser.Execute(command.Id.Value);

                if (IsValid(getUser)) {
                    command.Apply(result);

                    if (IsValid(result)) {
                        var updateUser = new UpdateUserPersistence();
                        updateUser.Execute(result);
                        IsValid(updateUser);
                    }
                }
            }

            if (!IsValid())
                result = null;

            return result;
        }

    }
}
