using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System.Text.RegularExpressions;
using System;
namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.RequiredIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_empty_valid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.RequiredIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_list_item_null_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { string.Empty, null }
            };

            notification.Clear();
            notification.RequiredIsValid(array.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(array, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_list_item_empty_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { string.Empty, string.Empty }
            };

            notification.Clear();
            notification.RequiredIsValid(array.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(array, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_list_no_item_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { }
            };

            notification.Clear();
            notification.RequiredIsValid(array.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(array, x => x.String);
            Assert.False(notification.IsValid());
        }


        [Fact]
        public void Check_list_null_invalid()
        {
            var array = new ArrayValues
            {
                String = null
            };

            notification.Clear();
            notification.RequiredIsValid(array.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RequiredIsValid(array, x => x.String);
            Assert.False(notification.IsValid());
        }
    }
}
