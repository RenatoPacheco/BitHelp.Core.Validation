using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinDateTimeIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();
        private DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(15).ToString()
            };

            notification.Clear();
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(10).ToString()
            };

            notification.Clear();
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(9).ToString()
            };

            notification.Clear();
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
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
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
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
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
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
            notification.MinDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(notification.IsValid());
        }
    }
}
