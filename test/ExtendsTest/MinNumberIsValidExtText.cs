using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinNumberIsValidExtText
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            SingleValues single = new SingleValues
            {
                String = "15"
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            SingleValues single = new SingleValues
            {
                String = "10"
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            SingleValues single = new SingleValues
            {
                String = "9"
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.MinNumberIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinNumberIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }
    }
}
