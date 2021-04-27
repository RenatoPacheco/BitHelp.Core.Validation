using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxTimeSpanIsValidExtText
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(5).ToString()
            };

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(10).ToString()
            };

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(11).ToString()
            };

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
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
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
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
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
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
            _notification.MaxTimeSpanIsValid(single.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxTimeSpanIsValid(single, x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxTimeSpanIsValid(x => x.String, TimeSpan.FromMinutes(10));
            Assert.True(single.IsValid());
        }
    }
}
