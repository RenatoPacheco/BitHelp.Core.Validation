using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinTimeSpanIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(15).ToString()
            };

            notification.Clear();
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            notification.Clear();
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(9).ToString()
            };

            notification.Clear();
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }
    }
}
