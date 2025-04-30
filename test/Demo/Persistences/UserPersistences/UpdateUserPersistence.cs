using System;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Persistences.UserPersistences {

    public class UpdateUserPersistence
        : Common.BasePersistence {

        public void Execute(User use) {
            use.UpdatedAt = DateTime.UtcNow;
        }
    }
}
