using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinTimeSpanIsValidExtText
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(15).ToString()
            };

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(9).ToString()
            };

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
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
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
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
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
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
            _notification.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.MinTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }
    }
}
