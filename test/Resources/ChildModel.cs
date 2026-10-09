using System.ComponentModel.DataAnnotations;
using BitHelp.Core.Validation.Extends;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class ChildModel : ISelfValidation
    {
        private string _email;

        [Display(Name = "Email")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                this.RemoveAtReference(x => x.Email);
                this.NotEmptyIsValid(x => x.Email);
                this.EmailIsValid(x => x.Email);
            }
        }

        private int? _age;

        [Display(Name = "Age")]
        public int? Age
        {
            get => _age;
            set
            {
                _age = value;
                this.RemoveAtReference(x => x.Age);
                this.RangeNumberIsValid(x => x.Age, 1, 150);
            }
        }

        public ValidationNotification Notifications { get; } = new();

        public bool IsValid()
        {
            this.RequiredIsValid(x => x.Email);
            this.RequiredIsValid(x => x.Age);
            return Notifications.IsValid();
        }
    }
}
