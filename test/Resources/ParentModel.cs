using System.Collections.Generic;
using BitHelp.Core.Validation.Extends;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class ParentModel : ISelfValidation
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notifications.RemoveAtReference(nameof(Name));
                Notifications.RequiredIsValid(this, x => x.Name);
                Notifications.MinCharactersIsValid(this, x => x.Name, 3);
            }
        }

        public ChildModel Child { get; set; }

        public List<ChildModel> Children { get; set; }

        public ValidationNotification Notifications { get; } = new();

        public bool IsValid()
        {
            Notifications.RequiredIsValid(this, x => x.Name);

            if (Child != null)
            {
                this.InheritItemNotifications(x => x.Child);
            }

            if (Children != null)
            {
                this.InheritItemsNotifications(x => x.Children);
            }

            return Notifications.IsValid();
        }
    }
}
