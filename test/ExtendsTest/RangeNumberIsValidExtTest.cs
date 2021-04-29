using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeNumberIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
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
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 0));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 0));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 4));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 4));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single.String, 5, 5));
            Assert.Throws<ArgumentException>(() => _notification.RangeNumberIsValid(single, x => x.String, 5, 5));
            Assert.Throws<ArgumentException>(() => single.RangeNumberIsValid(x => x.String, 5, 5));
        }
    }
}
