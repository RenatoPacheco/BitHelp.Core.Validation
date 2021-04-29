using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinCharactersIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_characters_is_in_minimum_10_valid()
        {
            var single = new SingleValues
            {
                String = "123456789012345"
            };

            _notification.Clear();
            _notification.MinCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_characters_is_in_minimum_10_valid()
        {
            var single = new SingleValues
            {
                String = "1234567890"
            };

            _notification.Clear();
            _notification.MinCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_characters_is_in_minimum_10_invalid()
        {
            var single = new SingleValues
            {
                String = "123456789"
            };

            _notification.Clear();
            _notification.MinCharactersIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinCharactersIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinCharactersIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MinCharactersIsValid(single.String, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinCharactersIsValid(single, x => x.String, 10);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinCharactersIsValid(x => x.String, 10);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.MinCharactersIsValid(single.String, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinCharactersIsValid(single, x => x.String, 10);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinCharactersIsValid(x => x.String, 10);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_minimum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.MinCharactersIsValid(single.String, 0));
            Assert.Throws<ArgumentException>(() => _notification.MinCharactersIsValid(single, x => x.String, 0));
            Assert.Throws<ArgumentException>(() => single.MinCharactersIsValid(x => x.String, 0));
        }
    }
}
