using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenEnumIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        readonly Enum[] _options = new Enum[] { EnumValue.Guid, EnumValue.Enum, EnumValue.Number };

        [Fact]
        public void Check_contain_value_guid_valid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.Guid
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_string_invalid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.String
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.EnumNull, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.EnumNull, _options);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                EnumNull = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, new Enum[] { }));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, new Enum[] { }));
        }
    }
}
