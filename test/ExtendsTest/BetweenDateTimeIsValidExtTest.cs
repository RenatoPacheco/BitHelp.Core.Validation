using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenDateTimeIsValidExtTest
    {
        public BetweenDateTimeIsValidExtTest()
        {
            _options = new DateTime[]
            {
                _date.AddDays(1),
                _date.AddDays(2),
                _date.AddDays(3)
            };
        }

        private readonly ValidationNotification _notification = new();
        private readonly DateTime _date = DateTime.Now;
        private readonly DateTime[] _options;

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = _date.AddDays(1).ToString()
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.Equal(!denay, single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_10_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = _date.AddDays(10).ToString()
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.Equal(denay, single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_text_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, denay);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, denay);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.False(single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_null_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, denay);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_null_exception(bool denay)
        {
            SingleValues single = new()
            {
                String = null
            };

            DateTime[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(single.String, options, null, denay));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_empty_exception(bool denay)
        {
            SingleValues single = new()
            {
                String = null
            };

            DateTime[] options = Array.Empty<DateTime>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, options, null, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(single.String, options, null, denay));
        }
    }
}
