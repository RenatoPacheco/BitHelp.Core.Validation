using System;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Test.Demo.Scopes.Common {
    public abstract class BaseEscp<TClasse>
        where TClasse : ISelfValidation {
        public BaseEscp(TClasse entity) {
            _entity = entity;
        }

        protected readonly TClasse _entity;

        public void RemoveAtReference(Expression<Func<TClasse, object>> expression) {
            _entity.Notifications.RemoveAtReference(expression);
        }
    }
}
