using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenTimeSpanIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        readonly TimeSpan[] options = new TimeSpan[] { TimeSpan.FromDays(1), TimeSpan.FromDays(2), TimeSpan.FromDays(3) };

        [Fact]
        public void Check_contain_value_1_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromDays(1).ToString()
            };

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromDays(10).ToString()
            };

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenTimeSpanIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenTimeSpanIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => notification.BetweenTimeSpanIsValid(single, x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenTimeSpanIsValid(single.String, new TimeSpan[] { }));
            Assert.Throws<ArgumentException>(() => notification.BetweenTimeSpanIsValid(single, x => x.String, new TimeSpan[] { }));
        }
    }
}
