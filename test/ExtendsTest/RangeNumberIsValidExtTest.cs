using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeNumberIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                Int = 15
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                Int = 10
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                Int = 20
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                Int = 9
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                Int = 21
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.String, 10, 20);
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
            notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.String, 10, 20);
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
            notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid(single, x => x.String, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single.String, 5, 0));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single, x => x.String, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single.String, 5, 4));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single, x => x.String, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single.String, 5, 5));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberIsValid(single, x => x.String, 5, 5));
        }
    }
}
