using System;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Persistences.UserPersistences {

    public class GetUserPersistence
        : Common.BasePersistence {

        public User Execute(Guid id) {
            return new User();
        }
    }
}
