using System.Linq;
using BitHelp.Core.Validation.Test.Demo.Entities;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;
using BitHelp.Core.Validation.Test.Demo.Persistences.UserPers;

namespace BitHelp.Core.Validation.Test.Demo.Services.UserServs {

    public class PatchUserServ
        : Common.BaseServ {

        public User Execute(PatchUserCmd command) {
            Notifications.Clear();
            User result = null;

            if (IsValid(command)) {

                var searchUser = new SearchUserPers();
                var cmdUser = new SearchUserCmd(command.Id.Value);

                result = searchUser.Execute(cmdUser).FirstOrDefault();

                if (IsValid(searchUser)) {
                    if (command.Apply(result)) {
                        if (IsValid(result)) {
                            var updateUser = new UpdateUserPers();
                            updateUser.Execute(result);
                            IsValid(updateUser);
                        }
                    }
                }
            }

            if (!IsValid())
                result = null;

            return result;
        }

    }
}
