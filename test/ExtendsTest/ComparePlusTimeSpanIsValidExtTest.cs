using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class ComparePlusTimeSpanIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_all_null_valid()
        {
            SingleValues single = new()
            {
                String = null,
                TimeSpanNull = null
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = null
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_null_valid()
        {
            SingleValues single = new()
            {
                String = null,
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_less_invalid()
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(456)
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_plus_valid()
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromMinutes(456).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }
    }
}