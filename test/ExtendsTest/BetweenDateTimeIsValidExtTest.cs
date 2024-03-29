﻿using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenDateTimeIsValidExtTest
    {
        public BetweenDateTimeIsValidExtTest()
        {
            _options = new DateTime[]
            {
                _date.AddDays(1),
                _date.AddDays(2),
                _date.AddDays(3)
            };
        }

        private readonly ValidationNotification _notification = new();
        private readonly DateTime _date = DateTime.Now;
        private readonly DateTime[] _options;

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool deny)
        {
            SingleValues single = new()
            {
                String = _date.AddDays(1).ToString(),
                DateTime = _date.AddDays(1)
            };

            #region string

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.Equal(!deny, single.IsValid());

            #endregion

            #region datetime

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.DateTime, _options, null, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.DateTime, _options, null, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.DateTime, _options, null, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.DateTime, _options, null, deny);
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
                String = _date.AddDays(10).ToString(),
                DateTime = _date.AddDays(10)
            };

            #region string

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.Equal(deny, single.IsValid());

            #endregion

            #region datetime

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.DateTime, _options, null, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.DateTime, _options, null, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.DateTime, _options, null, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.DateTime, _options, null, deny);
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
            _notification.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, deny);
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
                DateTimeNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, _options, null, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, _options, null, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.String, _options, null, deny);
            Assert.True(single.IsValid());

            #endregion

            #region datetime

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.DateTimeNull, _options, null, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.DateTimeNull, _options, null, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.DateTimeNull, _options, null, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(single.DateTimeNull, _options, null, deny);
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

            DateTime[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(single.String, options, null, deny));
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

            DateTime[] options = Array.Empty<DateTime>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, options, null, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(single.String, options, null, deny));
        }
    }
}
