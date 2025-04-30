using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Demo.Scopes;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Commands.UserCmds {

    public class InsertUserCmd
        : ISelfValidation {

        public InsertUserCmd() {
            _scpUser = new UserScope<InsertUserCmd>(this);
        }

        protected string _name;
        public string Name {
            get => _name;
            set {
                _name = value;
                _scpUser.NameIsValid(x => x.Name);
            }
        }

        protected string _email;
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
                this.RequiredIsValid(x => x.Password);
                ConfirmPassword = ConfirmPassword;
            }
        }

        protected string _confirmPassword;
        public string ConfirmPassword {
            get => _confirmPassword;
            set {
                _confirmPassword = value;
                _scpUser.PasswordIsValid(x => x.ConfirmPassword);
                this.CompareEqualIsValid(x => x.ConfirmPassword, y => y.Password);
                this.RequiredIsValid(x => x.ConfirmPassword);
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
                _scpUser.AndressIsValid(x => x.Address);
            }
        }

        public bool Apply(ref User user) {
            if (IsValid()) {
                user = new() {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Phone = Phone,
                    Address = Address
                };
                return true;
            }
            return false;
        }

        #region Auto ISelfValidation

        protected readonly UserScope<InsertUserCmd> _scpUser;

        protected readonly ValidationNotification _notifications = new();
        ValidationNotification ISelfValidation.Notifications => _notifications;

        public bool IsValid() {

            this.RequiredIsValid(x => x.Name);
            this.RequiredIsValid(x => x.Email);
            this.RequiredIsValid(x => x.Password);
            this.RequiredIsValid(x => x.Phone);
            this.RequiredIsValid(x => x.Address);

            return _notifications.IsValid();
        }

        #endregion

    }
}
