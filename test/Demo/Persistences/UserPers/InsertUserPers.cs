using System;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Persistences.UserPers {

    public class InsertUserPers
        : Common.BasePersistence {

        public void Execute(User user) {
            Notifications.Clear();

            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;
        }
    }
}
