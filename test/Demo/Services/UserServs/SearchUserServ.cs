using System;
using BitHelp.Core.Validation.Test.Demo.Entities;
using BitHelp.Core.Validation.Test.Demo.Commands.UserCmds;
using BitHelp.Core.Validation.Test.Demo.Persistences.UserPers;

namespace BitHelp.Core.Validation.Test.Demo.Services.UserServs {

    public class SearchUserServ
        : Common.BaseServ {

        public User[] Execute(SearchUserCmd command) {
            Notifications.Clear();
            User[] result = Array.Empty<User>();

            if (IsValid(command)) {
                var searchUser = new SearchUserPers();
                result = searchUser.Execute(command);
                IsValid(searchUser);
            }

            return result;
        }

    }
}
