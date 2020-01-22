using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxCharactersIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_8_characters_is_in_maximum_10_valid()
        {
            var single = new SingleValues
            {
                String = "12345678"
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_characters_is_in_maximum_10_valid()
        {
            var single = new SingleValues
            {
                String = "1234567890"
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_11_characters_is_in_maximum_10_invalid()
        {
            var single = new SingleValues
            {
                String = "12345678901"
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_empty_valid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.MaxCharactersIsValid(single.String, 0));
            Assert.Throws<ArgumentException>(() => notification.MaxCharactersIsValid(single, x => x.String, 0));
        }
    }
}
