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

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_guid_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = EnumValue.Guid.ToString(),
                Enum = EnumValue.Guid
            };

            #region string

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion

            #region enum

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.Enum, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.Enum, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_string_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = EnumValue.String.ToString(),
                Enum = EnumValue.String
            };

            #region string

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            #endregion

            #region enum

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.Enum, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.Enum, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.Enum, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.Enum, _options, denay);
            Assert.Equal(denay, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_null_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = null,
                EnumNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.String, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.String, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.String, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.String, _options, denay);
            Assert.True(single.IsValid());

            #endregion

            #region enum

            _notification.Clear();
            _notification.BetweenEnumIsValid(single.EnumNull, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenEnumIsValid(single, x => x.EnumNull, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(x => x.EnumNull, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenEnumIsValid(single.EnumNull, _options, denay);
            Assert.True(single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_null_exception(bool denay)
        {
            SingleValues single = new()
            {
                EnumNull = null
            };

            Enum[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(single.EnumNull, options, denay));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_empty_exception(bool denay)
        {
            SingleValues single = new()
            {
                EnumNull = null
            };

            Enum[] options = Array.Empty<Enum>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenEnumIsValid(single, x => x.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(x => x.EnumNull, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenEnumIsValid(single.EnumNull, options, denay));
        }
    }
}
