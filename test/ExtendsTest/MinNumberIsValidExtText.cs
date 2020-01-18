using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinNumberIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_min_number_valid()
        {

            var single = new SingleValues
            {
                String = "123"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 123);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid<SingleValues>(single, x => x.String, 123);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_min_number_invalid()
        {

            var single = new SingleValues
            {
                String = "123"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 124);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid<SingleValues>(single, x => x.String, 124);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_not_number_invalid()
        {

            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 101);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid<SingleValues>(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_null_valid()
        {

            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 101);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid<SingleValues>(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
