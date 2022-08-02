using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EnumIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_is_valid()
        {
            SingleValues single = new()
            {
                Enum = EnumValue.DateTime
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Enum, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Enum, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.Enum, typeof(EnumValue));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_string_is_valid()
        {
            SingleValues single = new()
            {
                String = EnumValue.DateTime.ToString()
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.String, typeof(EnumValue));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_string_is_invalid()
        {
            SingleValues single = new()
            {
                String = "sometext"
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.String, typeof(EnumValue));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.String, typeof(EnumValue));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_number_is_valid()
        {
            SingleValues single = new()
            {
                Int = (int)EnumValue.DateTime
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Int, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.Int, typeof(EnumValue));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_number_is_invalid()
        {
            SingleValues single = new()
            {
                Int = 100
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Int, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.Int, typeof(EnumValue));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.String, typeof(EnumValue));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(single.IsValid());
        }
    }
}
