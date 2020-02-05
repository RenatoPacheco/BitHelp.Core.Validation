using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class TimeSpanIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_10_days_valid()
        {
            var single = new SingleValues
            {
                TimeSpan = TimeSpan.FromDays(10)
            };

            notification.Clear();
            notification.TimeSpanIsValid(single.TimeSpan);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.TimeSpanIsValid(single, x => x.TimeSpan);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_10_minutes_as_string_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            notification.Clear();
            notification.TimeSpanIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_0_time_as_string_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(0).ToString()
            };

            notification.Clear();
            notification.TimeSpanIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.TimeSpanIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }
    }
}
