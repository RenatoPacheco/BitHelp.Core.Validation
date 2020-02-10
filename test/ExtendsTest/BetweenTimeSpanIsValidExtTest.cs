using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenTimeSpanIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        readonly TimeSpan[] _options = new TimeSpan[] { TimeSpan.FromDays(1), TimeSpan.FromDays(2), TimeSpan.FromDays(3) };

        [Fact]
        public void Check_contain_value_1_valid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromDays(1).ToString()
            };

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            var single = new SingleValues
            {
                String = TimeSpan.FromDays(10).ToString()
            };

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single.String, _options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenTimeSpanIsValid(single, x => x.String, _options);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single, x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single.String, Array.Empty<TimeSpan>()));
            Assert.Throws<ArgumentException>(() => _notification.BetweenTimeSpanIsValid(single, x => x.String, Array.Empty<TimeSpan>()));
        }
    }
}
