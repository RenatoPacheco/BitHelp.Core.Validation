using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxDateTimeIsValidExtText
    {
        private readonly ValidationNotification _notification = new();
        private readonly DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            SingleValues single = new()
            {
                String = date.AddDays(5).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            SingleValues single = new()
            {
                String = date.AddDays(10).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            SingleValues single = new()
            {
                String = date.AddDays(11).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
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
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
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
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
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
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.MaxDateTimeIsValid(x => x.String, date.AddDays(10));
            Assert.True(single.IsValid());
        }
    }
}
