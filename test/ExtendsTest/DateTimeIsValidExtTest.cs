using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DateTimeIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_date_en_US_valid()
        {
            var single = new SingleValues
            {
                String = "12/22/2020"
            };

            notification.Clear();
            notification.DateTimeIsValid(single.String, new CultureInfo("en-US"));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.DateTimeIsValid<SingleValues>(single, x => x.String, new CultureInfo("en-US"));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_date_en_US_Invalid()
        {
            var single = new SingleValues
            {
                String = "22/12/2020"
            };

            notification.Clear();
            notification.DateTimeIsValid(single.String, new CultureInfo("en-US"));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.DateTimeIsValid<SingleValues>(single, x => x.String, new CultureInfo("en-US"));
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_date_pt_BR_valid()
        {
            var single = new SingleValues
            {
                String = "22/12/2020"
            };

            notification.Clear();
            notification.DateTimeIsValid(single.String, new CultureInfo("pt-BR"));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.DateTimeIsValid<SingleValues>(single, x => x.String, new CultureInfo("pt-BR"));
            Assert.True(notification.IsValid());
        }
    }
}
