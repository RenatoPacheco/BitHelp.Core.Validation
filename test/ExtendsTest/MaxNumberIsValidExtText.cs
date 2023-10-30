using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxNumberIsValidExtText
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            SingleValues single = new()
            {
                String = "5"
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            SingleValues single = new()
            {
                String = "10"
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            SingleValues single = new()
            {
                String = "11"
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new()
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MaxNumberIsValid(single.String, 10);
            Assert.True(single.IsValid());
        }
    }
}
