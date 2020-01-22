using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeCharactersIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_characters_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                String = "123456789012345"
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_characters_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                String = "1234567890"
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_20_characters_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                String = "12345678901234567890"
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_characters_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                String = "123456789"
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_21_characters_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                String = "123456789012345678901"
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.RangeCharactersIsValid(single.String, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeCharactersIsValid(single, x => x.String, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_minimum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single.String, 0, 10));
            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single, x => x.String, 0, 10));
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single.String, 5, 0));
            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single, x => x.String, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single.String, 5, 4));
            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single, x => x.String, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single.String, 5, 5));
            Assert.Throws<ArgumentException>(() => notification.RangeCharactersIsValid(single, x => x.String, 5, 5));
        }
    }
}
