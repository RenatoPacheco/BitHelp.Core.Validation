using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenEnumIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        readonly Enum[] options = new Enum[] { EnumValue.Guid, EnumValue.Enum, EnumValue.Number };

        [Fact]
        public void Check_contain_value_guid_valid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.Guid
            };

            notification.Clear();
            notification.BetweenEnumIsValid(single.Enum, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenEnumIsValid(single, x => x.Enum, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_string_invalid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.String
            };

            notification.Clear();
            notification.BetweenEnumIsValid(single.Enum, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenEnumIsValid(single, x => x.Enum, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            notification.Clear();
            notification.BetweenEnumIsValid(single.EnumNull, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenEnumIsValid(single, x => x.EnumNull, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenEnumIsValid(single.EnumNull, null));
            Assert.Throws<ArgumentException>(() => notification.BetweenEnumIsValid(single, x => x.EnumNull, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenEnumIsValid(single.EnumNull, new Enum[] { }));
            Assert.Throws<ArgumentException>(() => notification.BetweenEnumIsValid(single, x => x.EnumNull, new Enum[] { }));
        }
    }
}
