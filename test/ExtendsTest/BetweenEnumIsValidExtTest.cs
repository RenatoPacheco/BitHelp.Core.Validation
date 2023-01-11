using Xunit;
using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System.Collections.Generic;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenEnumIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly Type _type = typeof(EnumValue);
        private readonly Enum[] _options = new Enum[] { EnumValue.Guid, EnumValue.Enum, EnumValue.Number };

        [Theory]
        [InlineData(EnumValue.Guid, false, false)]
        [InlineData(EnumValue.Guid, true, true)]
        [InlineData(EnumValue.Guid, true, false)]
        [InlineData(EnumValue.Guid, false, true)]
        [InlineData("Guid", false, false)]
        [InlineData("Guid", true, true)]
        [InlineData("Guid", true, false)]
        [InlineData("Guid", false, true)]
        [InlineData("guid", true, true)]
        [InlineData("guid", true, false)]
        [InlineData((int)EnumValue.Guid, false, false)]
        [InlineData((int)EnumValue.Guid, true, true)]
        [InlineData((int)EnumValue.Guid, true, false)]
        [InlineData((int)EnumValue.Guid, false, true)]
        public void Check_contain_value_valid(object value, bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single, x => x.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                x => x.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(!denay, single.IsValid());
        }

        [Theory]
        [InlineData(EnumValue.String, false, false)]
        [InlineData(EnumValue.String, true, true)]
        [InlineData(EnumValue.String, true, false)]
        [InlineData(EnumValue.String, false, true)]
        public void Check_contain_value_invalid(object value, bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single, x => x.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                x => x.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.Equal(denay, single.IsValid());
        }

        [Theory]
        [InlineData("guid", false, false)]
        [InlineData("guid", false, true)]
        [InlineData("other", false, false)]
        [InlineData("other", false, true)]
        [InlineData("other", true, false)]
        [InlineData("other", true, true)]
        [InlineData("Other", false, false)]
        [InlineData("Other", false, true)]
        [InlineData("Other", true, false)]
        [InlineData("Other", true, true)]
        [InlineData(null, false, false)]
        [InlineData(null, false, true)]
        [InlineData(null, true, false)]
        [InlineData(null, true, true)]
        [InlineData("", false, false)]
        [InlineData("", false, true)]
        [InlineData("", true, false)]
        [InlineData("", true, true)]
        [InlineData(100, false, false)]
        [InlineData(100, false, true)]
        [InlineData(100, true, false)]
        [InlineData(100, true, true)]
        [InlineData(EnumDiffValue.DateTime, false, false)]
        [InlineData(EnumDiffValue.DateTime, false, true)]
        [InlineData(EnumDiffValue.DateTime, true, false)]
        [InlineData(EnumDiffValue.DateTime, true, true)]
        public void Check_ignore_invalid_value_even_converted(object value, bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(
                single, x => x.Object, _type, _options, ignoreCase, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                x => x.Object, _type, _options, ignoreCase, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(
                single.Object, _type, _options, ignoreCase, denay);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Check_option_null_exception(bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = null
            };

            IList<Enum> options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Check_option_empty_exception(bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = null
            };

            IList<Enum> options = Array.Empty<Enum>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void Check_option_diff_types_exception(bool ignoreCase, bool denay)
        {
            SingleValues single = new()
            {
                Object = null
            };

            IList<Enum> options = new Enum[] { EnumValue.Guid, EnumDiffValue.Number };

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.Object, _type, options, ignoreCase, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(single.Object, _type, options, ignoreCase, denay));
        }
    }
}
