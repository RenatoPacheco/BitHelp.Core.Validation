using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class TimeSpanIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_10_days_valid()
        {
            var single = new SingleValues
            {
                TimeSpan = TimeSpan.FromDays(10)
            };

            _notification.Clear();
            _notification.TimeSpanIsValid(single.TimeSpan);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.TimeSpanIsValid(single, x => x.TimeSpan);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.TimeSpanIsValid(x => x.TimeSpan);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_10_minutes_as_string_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            _notification.Clear();
            _notification.TimeSpanIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.TimeSpanIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_0_time_as_string_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(0).ToString()
            };

            _notification.Clear();
            _notification.TimeSpanIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.TimeSpanIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.TimeSpanIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.TimeSpanIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.TimeSpanIsValid(x => x.String);
            Assert.True(single.IsValid());
        }
    }
}
