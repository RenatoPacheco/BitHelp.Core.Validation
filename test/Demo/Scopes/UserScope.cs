using System;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Extends;

namespace BitHelp.Core.Validation.Test.Demo.Scopes {

    public class UserScope<TClasse>
        : Common.BaseEscp<TClasse>
        where TClasse : ISelfValidation {

        public UserScope(TClasse entity)
            : base(entity) { }

        public void IdIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.GuidIsValid(expression);
        }

        public void NameIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.MaxCharactersIsValid(expression, 100);
        }

        public void EmailIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.EmailIsValid(expression);
            _entity.MaxCharactersIsValid(expression, 100);
        }

        public void PasswordIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.MinCharactersIsValid(expression, 6);
            _entity.MaxCharactersIsValid(expression, 20);
        }

        public void PhoneIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.RegexIsValid(expression, @"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$");
            _entity.MaxCharactersIsValid(expression, 14);
        }

        public void AddressIsValid(Expression<Func<TClasse, object>> expression) {
            RemoveAtReference(expression);
            _entity.NotEmptyIsValid(expression);
            _entity.MaxCharactersIsValid(expression, 100);
        }



    }
}
