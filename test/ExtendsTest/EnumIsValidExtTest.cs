using Xunit;
using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EnumIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, typeof(EnumValue), true)]
        [InlineData(null, typeof(EnumValue), false)]
        [InlineData(0, typeof(EnumValue), true)]
        [InlineData(0, typeof(EnumValue), false)]
        [InlineData("DateTime", typeof(EnumValue), true)]
        [InlineData("DateTime", typeof(EnumValue), false)]
        [InlineData("dateTime", typeof(EnumValue), true)]
        [InlineData(EnumValue.DateTime, typeof(EnumValue), true)]
        [InlineData(EnumValue.DateTime, typeof(EnumValue), false)]
        public void Check_is_valid(object value, Type type, bool ignoreCase)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Object, type, ignoreCase);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Object, type, ignoreCase);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.Object, type, ignoreCase);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.Object, type, ignoreCase);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(" ", typeof(EnumValue), true)]
        [InlineData(" ", typeof(EnumValue), false)]
        [InlineData("other", typeof(EnumValue), true)]
        [InlineData("other", typeof(EnumValue), false)]
        [InlineData("Other", typeof(EnumValue), true)]
        [InlineData("Other", typeof(EnumValue), false)]
        [InlineData(100, typeof(EnumValue), true)]
        [InlineData(100, typeof(EnumValue), false)]
        [InlineData(EnumDiffValue.DateTime, typeof(EnumValue), true)]
        [InlineData(EnumDiffValue.DateTime, typeof(EnumValue), false)]
        public void Check_is_invalid(object value, Type type, bool ignoreCase)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Object, type, ignoreCase);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Object, type, ignoreCase);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(x => x.Object, type, ignoreCase);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.EnumIsValid(single.Object, type, ignoreCase);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_type_not_enum_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Type type = typeof(string);

            Assert.Throws<ArgumentException>(() => _notification.EnumIsValid(single.String, type));
            Assert.Throws<ArgumentException>(() => _notification.EnumIsValid(single, x => x.String, type));
            Assert.Throws<ArgumentException>(() => single.EnumIsValid(x => x.String, type));
            Assert.Throws<ArgumentException>(() => single.EnumIsValid(single.String, type));
        }

        [Fact]
        public void Check_type_null_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Type type = null;

            Assert.Throws<ArgumentException>(() => _notification.EnumIsValid(single.String, type));
            Assert.Throws<ArgumentException>(() => _notification.EnumIsValid(single, x => x.String, type));
            Assert.Throws<ArgumentException>(() => single.EnumIsValid(x => x.String, type));
            Assert.Throws<ArgumentException>(() => single.EnumIsValid(single.String, type));
        }
    }
}
