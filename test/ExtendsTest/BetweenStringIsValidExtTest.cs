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

        [Fact]
        public void Check_contain_value_1_valid()
        {
            SingleValues single = new()
            {
                String = "1"
            };

            _notification.Clear();
            _notification.BetweenStringIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            SingleValues single = new()
            {
                String = "10"
            };

            _notification.Clear();
            _notification.BetweenStringIsValid(single.String, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.BetweenStringIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenStringIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenStringIsValid(x => x.String, _options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single, x => x.String, null));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single.String, Array.Empty<string>()));
            Assert.Throws<ArgumentException>(() => _notification.BetweenStringIsValid(single, x => x.String, Array.Empty<string>()));
            Assert.Throws<ArgumentException>(() => single.BetweenStringIsValid(x => x.String, Array.Empty<string>()));
        }
    }
}
