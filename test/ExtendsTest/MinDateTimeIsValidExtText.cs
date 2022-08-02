using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinDateTimeIsValidExtText
    {
        private readonly ValidationNotification _notification = new ValidationNotification();
        private readonly DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            SingleValues single = new SingleValues
            {
                String = date.AddDays(15).ToString()
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            SingleValues single = new SingleValues
            {
                String = date.AddDays(10).ToString()
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            SingleValues single = new SingleValues
            {
                String = date.AddDays(9).ToString()
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MinDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }
    }
}
