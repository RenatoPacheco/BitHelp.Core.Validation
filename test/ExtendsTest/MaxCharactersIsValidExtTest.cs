using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxCharactersIsValidExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_8_characters_is_in_maximum_10_valid()
        {
            SingleValues single = new SingleValues
            {
                String = "12345678"
            };

            _notification.Clear();
            _notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_characters_is_in_maximum_10_valid()
        {
            SingleValues single = new SingleValues
            {
                String = "1234567890"
            };

            _notification.Clear();
            _notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_11_characters_is_in_maximum_10_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "12345678901"
            };

            _notification.Clear();
            _notification.MaxCharactersIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxCharactersIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_valid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.MaxCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.MaxCharactersIsValid(single.String, 0));
            Assert.Throws<ArgumentException>(() => _notification.MaxCharactersIsValid(single, x => x.String, 0));
            Assert.Throws<ArgumentException>(() => single.MaxCharactersIsValid(x => x.String, 0));
        }
    }
}
