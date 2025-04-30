using BitHelp.Core.Validation.Test.Demo.Entities;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;
using BitHelp.Core.Validation.Test.Demo.Persistences.UserPersistences;

namespace BitHelp.Core.Validation.Test.Demo.Services.UserServs {
    public class InsertUserServ
        : Common.BaseServ {

        public User Execute(InsertUserCmd command) {
            Notifications.Clear();
            User result = null;

            if (IsValid(command)) {
                command.Apply(ref result);

                if (IsValid(result)) {
                    var insertUser = new InsertUserPersistence();
                    insertUser.Execute(result);
                    IsValid(insertUser);
                }
            }

            return result;
        }

    }
}
