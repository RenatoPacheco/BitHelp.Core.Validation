using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class GuidIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_guid_valid()
        {
            SingleValues single = new()
            {
                String = "3b8e6bc1-82eb-4339-998c-5f1fba019ae7"
            };

            _notification.Clear();
            _notification.GuidIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.GuidIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(x => x.String);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(single.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_empty_guid_valid()
        {
            SingleValues single = new()
            {
                String = "00000000-0000-0000-0000-000000000000"
            };

            _notification.Clear();
            _notification.GuidIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.GuidIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(x => x.String);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(single.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_empty_is_invalid()
        {
            SingleValues single = new()
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.GuidIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.GuidIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(x => x.String);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(single.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_null_is_valid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.GuidIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.GuidIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(x => x.String);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(single.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_invalid()
        {
            SingleValues single = new()
            {
                String = "3b8e6bc1-ghij-klmn-opqr-5f1fba019ae7"
            };

            _notification.Clear();
            _notification.GuidIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.GuidIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(x => x.String);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.GuidIsValid(single.String);
            Assert.False(single.IsValid());
        }
    }
}
