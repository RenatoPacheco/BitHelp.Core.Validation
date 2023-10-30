using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeNumberIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                Int = 15
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.Int, 10, 20);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                Int = 10
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.Int, 10, 20);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                Int = 20
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.Int, 10, 20);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new()
            {
                Int = 9
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.Int, 10, 20);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new()
            {
                Int = 21
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.Int, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.Int, 10, 20);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.String, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.String, 10, 20);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new()
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.String, 10, 20);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.String, 10, 20);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.String, 10, 20);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.RangeNumberIsValid(single.String, 10, 20);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeNumberIsValid(single, x => x.String, 10, 20);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(x => x.String, 10, 20);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RangeNumberIsValid(single.String, 10, 20);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 0));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 0));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 0));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(single.String, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 4));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 4));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 4));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(single.String, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 5));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 5));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 5));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(single.String, 5, 5));
        }
    }
}
