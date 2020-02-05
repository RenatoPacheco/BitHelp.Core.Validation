using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeDateTimeIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        private DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_15_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                DateTime = date.AddDays(15)
            };

            notification.Clear();
            notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                DateTime = date.AddDays(10)
            };

            notification.Clear();
            notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_20_is_in_range_10_and_20_valid()
        {
            var single = new SingleValues
            {
                DateTime = date.AddDays(20)
            };

            notification.Clear();
            notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                DateTime = date.AddDays(9)
            };

            notification.Clear();
            notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_21_is_in_range_10_and_20_invalid()
        {
            var single = new SingleValues
            {
                DateTime = date.AddDays(21)
            };

            notification.Clear();
            notification.RangeDateTimeIsValid(single.DateTime, date.AddDays(10), date.AddDays(20));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.DateTime, date.AddDays(10), date.AddDays(20));
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
            notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
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
            notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
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
            notification.RangeDateTimeIsValid(single.String, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(10), date.AddDays(20));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeDateTimeIsValid(single.String, date.AddDays(5), date.AddDays(4)));
            Assert.Throws<ArgumentException>(() => notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(5), date.AddDays(4)));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeDateTimeIsValid(single.String, date.AddDays(5), date.AddDays(5)));
            Assert.Throws<ArgumentException>(() => notification.RangeDateTimeIsValid(single, x => x.String, date.AddDays(5), date.AddDays(5)));
        }
    }
}
