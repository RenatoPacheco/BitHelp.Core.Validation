using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BitHelp.Core.Validation.Test.Demo.Scopes;

namespace BitHelp.Core.Validation.Test.Demo.Commands.UserCmds {

    public class SearchUserCmd
        : ISelfValidation {

        public SearchUserCmd() {
            
        }

        public SearchUserCmd(Guid userId) {
            UserIds = new Guid[] { userId };
            Max = 1;
            Page = 1;
        }

        public SearchUserCmd(IEnumerable<Guid> userIds) {
            UserIds = userIds.ToArray();
            Max = UserIds.Length;
            Page = 1;
        }

        public Guid[] UserIds { get; set; }

        public string[] UserNames { get; set; }

        public string Text { get; set; }

        public int Page { get; set; }

        public int Max {  get; set; }

        #region Auto ISelfValidation

        protected readonly UserScope<InsertUserCmd> _scpUser;

        protected readonly ValidationNotification _notifications = new();
        ValidationNotification ISelfValidation.Notifications => _notifications;

        public bool IsValid() {
            return _notifications.IsValid();
        }

        #endregion
    }
}
