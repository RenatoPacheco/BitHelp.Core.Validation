using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeDateTimeIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                DateTime = date.AddDays(15)
            };

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                DateTime = date.AddDays(10)
            };

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            SingleValues single = new()
            {
                DateTime = date.AddDays(20)
            };

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new()
            {
                DateTime = date.AddDays(9)
            };

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            SingleValues single = new()
            {
                DateTime = date.AddDays(21)
            };

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.DateTime, date.AddDays(10), date.AddDays(20));
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
            _notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.String, date.AddDays(10), date.AddDays(20));
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
            _notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.String, date.AddDays(10), date.AddDays(20));
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
            _notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RangeDateTimeIsValid(x => x.String, date.AddDays(10), date.AddDays(20));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeDateTimeIsValid(single.String, date.AddDays(5), date.AddDays(4)));
            Assert.Throws<ArgumentException>(() => _notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(5), date.AddDays(4)));
            Assert.Throws<ArgumentException>(() => single.RangeDateTimeIsValid(x => x.String, date.AddDays(5), date.AddDays(4)));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeDateTimeIsValid(single.String, date.AddDays(5), date.AddDays(5)));
            Assert.Throws<ArgumentException>(() => _notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(5), date.AddDays(5)));
            Assert.Throws<ArgumentException>(() => single.RangeDateTimeIsValid(x => x.String, date.AddDays(5), date.AddDays(5)));
        }
    }
}
