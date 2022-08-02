using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeTimeSpanIsValidExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                TimeSpan = TimeSpan.FromMinutes(15)
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                TimeSpan = TimeSpan.FromMinutes(10)
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            SingleValues single = new SingleValues
            {
                TimeSpan = TimeSpan.FromMinutes(20)
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new SingleValues
            {
                TimeSpan = TimeSpan.FromMinutes(9)
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new SingleValues
            {
                TimeSpan = TimeSpan.FromMinutes(21)
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.TimeSpan, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(20));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeTimeSpanIsValid(single.String, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(4)));
            Assert.Throws<ArgumentException>(() => _notification.RangeTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(4)));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeTimeSpanIsValid(single.String, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5)));
            Assert.Throws<ArgumentException>(() => _notification.RangeTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5)));
        }
    }
}
