using BitHelp.Core.Validation.Test.Demo.Entities;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;

namespace BitHelp.Core.Validation.Test.Demo.Persistences.UserPers {

    public class SearchUserPers
        : Common.BasePersistence {

        public User[] Execute(SearchUserCmd command) {
            Notifications.Clear();

            return new User[] {
                new(),
                new(),
                new()
            };
        }
    }
}
