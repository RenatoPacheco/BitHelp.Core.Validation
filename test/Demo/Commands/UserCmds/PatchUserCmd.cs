using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Demo.Scopes;
using BitHelp.Core.Validation.Test.Demo.Entities;

namespace BitHelp.Core.Validation.Test.Demo.Commands.UserCmds {

    public class PatchUserCmd
        : Common.BasePatchCmd, ISelfValidation {

        public PatchUserCmd() {
            _scpUser = new UserScope<PatchUserCmd>(this);
        }

        protected Guid? _id;
        public Guid? Id {
            get => _id;
            set {
                _id = value;
                _scpUser.IdIsValid(x => x.Id);
            }
        }

        protected string _name;
        public string Name {
            get => _name;
            set {
                _name = value;
                RegisterField();
                _scpUser.NameIsValid(x => x.Name);
                this.RequiredIsValid(x => x.Name);
            }
        }

        protected string _email;
        public string Email {
            get => _email;
            set {
                _email = value;
                RegisterField();
                _scpUser.EmailIsValid(x => x.Email);
                this.RequiredIsValid(x => x.Email);
            }
        }

        protected string _password;
        public string Password {
            get => _password;
            set {
                _password = value;
                RegisterField();
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
                RegisterField();
                _scpUser.PasswordIsValid(x => x.ConfirmPassword);
                this.CompareEqualIsValid(x => x.ConfirmPassword, y => y.Password);
                this.RequiredIfOtherNotNullIsValid(x => x.ConfirmPassword, Password);
            }
        }

        protected string _phone;
        public string Phone {
            get => _phone;
            set {
                _phone = value;
                RegisterField();
                _scpUser.PhoneIsValid(x => x.Phone);
                this.RequiredIsValid(x => x.Phone);
            }
        }

        protected string _address;
        public string Address {
            get => _address;
            set {
                _address = value;
                RegisterField();
                _scpUser.AndressIsValid(x => x.Address);
                this.RequiredIsValid(x => x.Address);
            }
        }

        public bool Apply(User user) {
            if (user is null && HasRegisteredFields())
                throw new ArgumentNullException(nameof(user));

            if (IsValid() && HasRegisteredFields()) {

                if (IsFieldRegistered(nameof(Name)))
                    user.Name = Name;

                if (IsFieldRegistered(nameof(Email)))
                    user.Email = Email;

                if (IsFieldRegistered(nameof(Password)))
                    user.Password = Password;

                if (IsFieldRegistered(nameof(Phone)))
                    user.Phone = Phone;

                if (IsFieldRegistered(nameof(Address)))
                    user.Address = Address;
            }

            return HasRegisteredFields();
        }

        #region Auto ISelfValidation

        protected readonly UserScope<PatchUserCmd> _scpUser;

        protected readonly ValidationNotification _notifications = new();
        ValidationNotification ISelfValidation.Notifications => _notifications;

        public bool IsValid() {

            this.RequiredIsValid(x => x.Id);

            return _notifications.IsValid();
        }

        #endregion

    }
}
