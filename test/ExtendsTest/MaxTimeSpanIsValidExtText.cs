using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxTimeSpanIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(5).ToString()
            };

            notification.Clear();
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            notification.Clear();
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(11).ToString()
            };

            notification.Clear();
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
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
            notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(notification.IsValid());
        }
    }
}
