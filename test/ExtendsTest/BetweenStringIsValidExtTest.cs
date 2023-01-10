using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenStringIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly string[] _options = new string[] { "1", "2", "3" };

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = "1"
            };

            _notification.Clear();
            _notification.BetweenStringIsValid(single.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(single.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_10_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = "10"
            };

            _notification.Clear();
            _notification.BetweenStringIsValid(single.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(single.String, _options, denay);
            Assert.Equal(denay, single.IsValid());
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
            _notification.BetweenStringIsValid(single.String, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(single.String, _options, denay);
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

            string[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(single.String, options, denay));
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

            string[] options = Array.Empty<string>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(single.String, options, denay));
        }
    }
}
