using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenNumberIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        readonly decimal[] options = new decimal[] { 1, 2, 3 };
        [Fact]
        public void Check_contain_value_1_valid()
        {
            var single = new SingleValues
            {
                String = "1"
            };

            notification.Clear();
            notification.BetweenNumberIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenNumberIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            var single = new SingleValues
            {
                String = "10"
            };

            notification.Clear();
            notification.BetweenNumberIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenNumberIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.BetweenNumberIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenNumberIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.BetweenNumberIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenNumberIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenNumberIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => notification.BetweenNumberIsValid(single, x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenNumberIsValid(single.String, new decimal[] { }));
            Assert.Throws<ArgumentException>(() => notification.BetweenNumberIsValid(single, x => x.String, new decimal[] { }));
        }
    }
}
