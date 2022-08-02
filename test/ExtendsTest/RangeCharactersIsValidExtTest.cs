using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeCharactersIsValidExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_characters_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                String = "123456789012345"
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_characters_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                String = "1234567890"
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_20_characters_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                String = "12345678901234567890"
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_characters_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "123456789"
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_21_characters_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "123456789012345678901"
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeCharactersIsValid(x => x.String, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_minimum_less_1_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single.String, 0, 10));
            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single, x => x.String, 0, 10));
            Assert.Throws<ArgumentException>(() => single.RangeCharactersIsValid(x => x.String, 0, 10));
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single.String, 5, 0));
            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single, x => x.String, 5, 0));
            Assert.Throws<ArgumentException>(() => single.RangeCharactersIsValid(x => x.String, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single.String, 5, 4));
            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single, x => x.String, 5, 4));
            Assert.Throws<ArgumentException>(() => single.RangeCharactersIsValid(x => x.String, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single.String, 5, 5));
            Assert.Throws<ArgumentException>(() => _notification.RangeCharactersIsValid(single, x => x.String, 5, 5));
            Assert.Throws<ArgumentException>(() => single.RangeCharactersIsValid(x => x.String, 5, 5));
        }
    }
}
