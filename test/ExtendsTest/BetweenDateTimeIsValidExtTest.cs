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
            options = new DateTime[]
            {
                date.AddDays(1),
                date.AddDays(2),
                date.AddDays(3)
            };
        }

        private readonly ValidationNotification _notification = new();
        private readonly DateTime date = DateTime.Now;
        private readonly DateTime[] options;


        [Fact]
        public void Check_contain_value_1_valid()
        {
            SingleValues single = new()
            {
                String = date.AddDays(1).ToString()
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            SingleValues single = new()
            {
                String = date.AddDays(10).ToString()
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single.String, options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenDateTimeIsValid(x => x.String, options);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, null));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single.String, Array.Empty<DateTime>()));
            Assert.Throws<ArgumentException>(() => _notification.BetweenDateTimeIsValid(single, x => x.String, Array.Empty<DateTime>()));
            Assert.Throws<ArgumentException>(() => single.BetweenDateTimeIsValid(x => x.String, Array.Empty<DateTime>()));
        }
    }
}
