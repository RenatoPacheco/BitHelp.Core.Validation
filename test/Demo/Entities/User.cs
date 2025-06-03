using System;
using System.ComponentModel.DataAnnotations;
using BitHelp.Core.Validation.Test.Demo.Scopes;

namespace BitHelp.Core.Validation.Test.Demo.Entities {
    public class User
        : ISelfValidation {

        public User() {
            _scpUser = new UserScope<User>(this);
        }

        public Guid Id { get; set; }

        protected string _name;
        public string Name {
            get => _name;
            set {
                _name = value;
                _scpUser.NameIsValid(x => x.Name);
            }
        }

        protected string _email;
        [Display(Name = "E-mail")]
        public string Email {
            get => _email;
            set {
                _email = value;
                _scpUser.EmailIsValid(x => x.Email);
            }
        }

        protected string _password;
        public string Password {
            get => _password;
            set {
                _password = value;
                _scpUser.PasswordIsValid(x => x.Password);
            }
        }

        protected string _phone;
        public string Phone {
            get => _phone;
            set {
                _phone = value;
                _scpUser.PhoneIsValid(x => x.Phone);
            }
        }

        protected string _address;
        public string Address {
            get => _address;
            set {
                _address = value;
                _scpUser.AddressIsValid(x => x.Address);
            }
        }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        #region Auto ISelfValidation

        protected readonly UserScope<User> _scpUser;

        protected readonly ValidationNotification _notifications = new();
        ValidationNotification ISelfValidation.Notifications => _notifications;

        public bool IsValid() {
            return _notifications.IsValid();
        }

        #endregion
    }
}
