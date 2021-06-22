using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class NotNullOrEmptyIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_no_empty_valid()
        {
            var single = new SingleValues
            {
                String = "123"
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_empty_ignore_with_space_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String, true);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String, true);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String, true);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_null_is_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_with_space_invalid()
        {
            var single = new SingleValues
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_with_space_and_ignore_valid()
        {
            var single = new SingleValues
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single.String, true);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(single, x => x.String, true);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.NotNullOrEmptyIsValid(x => x.String, true);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_invalid_list_empty()
        {
            var array = new ArrayValues
            {
                String = Array.Empty<string>()
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_invalid_list_null()
        {
            var array = new ArrayValues
            {
                String = null
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_list_item_empty_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "             " }
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }


        [Fact]
        public void Check_list_item_null_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { null }
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotNullOrEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_list_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "123" }
            };

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotNullOrEmptyIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.NotNullOrEmptyIsValid(x => x.String);
            Assert.True(array.IsValid());
        }
    }
}
