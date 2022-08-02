using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class NotEmptyIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_no_empty_valid()
        {
            SingleValues single = new()
            {
                String = "123"
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_empty_invalid()
        {
            SingleValues single = new()
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_empty_ignore_with_space_invalid()
        {
            SingleValues single = new()
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String, true);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String, true);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String, true);
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
            _notification.NotEmptyIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_with_space_invalid()
        {
            SingleValues single = new()
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_with_space_and_ignore_valid()
        {
            SingleValues single = new()
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String, true);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String, true);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.NotEmptyIsValid(x => x.String, true);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_list_empty()
        {
            ArrayValues array = new()
            {
                String = Array.Empty<string>()
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.NotEmptyIsValid(x => x.String);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_ignore_list_null()
        {
            ArrayValues array = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.NotEmptyIsValid(x => x.String);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_list_item_empty_invalid()
        {
            ArrayValues array = new()
            {
                String = new string[] { "             " }
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }


        [Fact]
        public void Check_list_item_null_invalid()
        {
            ArrayValues array = new()
            {
                String = new string[] { null }
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.NotEmptyIsValid(x => x.String);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_list_valid()
        {
            ArrayValues array = new()
            {
                String = new string[] { "123" }
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.NotEmptyIsValid(x => x.String);
            Assert.True(array.IsValid());
        }
    }
}
