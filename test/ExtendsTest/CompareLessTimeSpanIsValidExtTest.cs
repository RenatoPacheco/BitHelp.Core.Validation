using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareLessTimeSpanIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_all_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                TimeSpanNull = null
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = null
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_less_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(456)
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(123).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_plus_invalid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromMinutes(456).ToString(),
                TimeSpanNull = TimeSpan.FromMinutes(123)
            };

            _notification.Clear();
            _notification.CompareLessTimeSpanIsValid(single, x => x.String, x => x.TimeSpanNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessTimeSpanIsValid(x => x.String, x => x.TimeSpanNull);
            Assert.False(single.IsValid());
        }
    }
}
