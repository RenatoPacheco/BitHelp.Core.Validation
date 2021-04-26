using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenNumberIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        readonly decimal[] _options = new decimal[] { 1, 2, 3 };
        [Fact]
        public void Check_contain_value_1_valid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_text_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, null));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, Array.Empty<decimal>()));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, Array.Empty<decimal>()));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, Array.Empty<decimal>()));
        }
    }
}
