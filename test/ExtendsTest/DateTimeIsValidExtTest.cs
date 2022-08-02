﻿using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System.Globalization;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DateTimeIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_date_en_US_valid()
        {
            SingleValues single = new()
            {
                String = "12/22/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new("en-US"));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new("en-US"));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(x => x.String, new("en-US"));
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_date_en_US_Invalid()
        {
            SingleValues single = new()
            {
                String = "22/12/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new("en-US"));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new("en-US"));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(x => x.String, new("en-US"));
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_date_pt_BR_valid()
        {
            SingleValues single = new()
            {
                String = "22/12/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new("pt-BR"));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new("pt-BR"));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(x => x.String, new("pt-BR"));
            Assert.True(single.IsValid());
        }
    }
}
