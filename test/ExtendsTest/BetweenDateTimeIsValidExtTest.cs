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

        readonly ValidationNotification notification = new ValidationNotification();
        readonly DateTime date = DateTime.Now;
        readonly DateTime[] options;


        [Fact]
        public void Check_contain_value_1_valid()
        {
            var single = new SingleValues
            {
                String = date.AddDays(1).ToString()
            };

            notification.Clear();
            notification.BetweenDateTimeIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_not_contain_value_10_invalid()
        {
            var single = new SingleValues
            {
                String = date.AddDays(10).ToString()
            };

            notification.Clear();
            notification.BetweenDateTimeIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.BetweenDateTimeIsValid(single.String, options);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.BetweenDateTimeIsValid(single.String, options);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BetweenDateTimeIsValid(single, x => x.String, options);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_option_null_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenDateTimeIsValid(single.String, null));
            Assert.Throws<ArgumentException>(() => notification.BetweenDateTimeIsValid(single, x => x.String, null));
        }

        [Fact]
        public void Check_option_empty_exception()
        {
            var single = new SingleValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.BetweenDateTimeIsValid(single.String, new DateTime[] { }));
            Assert.Throws<ArgumentException>(() => notification.BetweenDateTimeIsValid(single, x => x.String, new DateTime[] { }));
        }
    }
}