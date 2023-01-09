using Xunit;
using System;
using System.Collections.Generic;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenByteIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly byte[] _options = new byte[] { 1, 2, 3 };
        [Fact]
        public void Check_contain_value_1_valid()
        {
            SingleValues single = new()
            {
                String = "1"
            };

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options);
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
            _notification.BetweenNumberIsValid(single.String, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options);
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
            _notification.BetweenNumberIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<byte> options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<byte> options = Array.Empty<byte>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options));
        }
    }
}
