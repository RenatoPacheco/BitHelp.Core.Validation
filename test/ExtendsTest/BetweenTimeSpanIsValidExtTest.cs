using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenTimeSpanIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly TimeSpan[] _options = new TimeSpan[] { TimeSpan.FromDays(1), TimeSpan.FromDays(2), TimeSpan.FromDays(3) };

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool deny)
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromDays(1).ToString(),
                TimeSpan = TimeSpan.FromDays(1)
            };

            #region string

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.String, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            #endregion

            #region timespan

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.TimeSpan, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.TimeSpan, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.TimeSpan, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.TimeSpan, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_10_invalid(bool deny)
        {
            SingleValues single = new()
            {
                String = TimeSpan.FromDays(10).ToString(),
                TimeSpan = TimeSpan.FromDays(10)
            };

            #region string

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.String, _options, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.Equal(deny, single.IsValid());

            #endregion

            #region timespan

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.TimeSpan, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.TimeSpan, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.TimeSpan, _options, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.TimeSpan, _options, deny);
            Assert.Equal(deny, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_invalid_value_even_converted(bool deny)
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.String, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_null_valid(bool deny)
        {
            SingleValues single = new()
            {
                String = null,
                TimeSpanNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.String, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.String, _options, deny);
            Assert.True(single.IsValid());

            #endregion

            #region timespan

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.TimeSpanNull, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.TimeSpanNull, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(x => x.TimeSpanNull, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenTimeSpanIsValid(single.TimeSpanNull, _options, deny);
            Assert.True(single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_null_exception(bool deny)
        {
            SingleValues single = new()
            {
                String = null
            };

            TimeSpan[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single.String, options, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single, x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenTimeSpanIsValid(x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenTimeSpanIsValid(single.String, options, deny));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_empty_exception(bool deny)
        {
            SingleValues single = new()
            {
                String = null
            };

            TimeSpan[] options = Array.Empty<TimeSpan>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single.String, options, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single, x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenTimeSpanIsValid(x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenTimeSpanIsValid(single.String, options, deny));
        }
    }
}
