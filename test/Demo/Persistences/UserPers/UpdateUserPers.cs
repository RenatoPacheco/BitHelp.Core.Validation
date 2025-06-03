using System;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Persistences.UserPers {

    public class UpdateUserPers
        : Common.BasePersistence {

        public void Execute(User use) {
            Notifications.Clear();

            use.UpdatedAt = DateTime.UtcNow;
        }
    }
}
