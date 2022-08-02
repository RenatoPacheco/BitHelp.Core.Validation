using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenEnumIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly Enum[] _options = new Enum[] { EnumValue.Guid, EnumValue.Enum, EnumValue.Number };

        [Fact]
        public void Check_contain_value_guid_valid()
        {
            SingleValues single = new()
            {
                Enum = EnumValue.Guid
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.Enum, _options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_string_invalid()
        {
            SingleValues single = new()
            {
                Enum = EnumValue.String
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.Enum, _options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            SingleValues single = new()
            {
                EnumNull = null
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.EnumNull, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.EnumNull, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.EnumNull, _options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            SingleValues single = new()
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, null));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.EnumNull, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            SingleValues single = new()
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, Array.Empty<Enum>()));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, Array.Empty<Enum>()));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.EnumNull, Array.Empty<Enum>()));
        }
    }
}
