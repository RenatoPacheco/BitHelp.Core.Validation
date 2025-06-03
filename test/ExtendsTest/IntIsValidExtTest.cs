using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class IntIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null)]
        [InlineData(123)]
        [InlineData("123")]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Check_value_is_valid(object value)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData(long.MaxValue)]
        [InlineData(long.MinValue)]
        public void Check_value_not_is_valid(object value)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.False(single.IsValid());
        }

        [Theory]
        [InlineData(123, 456)]
        [InlineData(123, "456")]
        [InlineData("123", "456")]
        [InlineData("123", 456)]
        [InlineData(null, null)]
        [InlineData(null, 123)]
        public void Check_value_array_is_valid(params object[] value)
        {
            ArrayValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("abc")]
        [InlineData("", 123)]
        [InlineData("abc", 123)]
        public void Check_value_array_not_is_valid(params object[] value)
        {
            ArrayValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_empty_array_is_valid()
        {
            ArrayValues single = new()
            {
                Object = Array.Empty<object>()
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_null_array_is_valid()
        {
            ArrayValues single = new()
            {
                Object = null
            };

            _notification.Clear();
            _notification.IntIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.IntIsValid(single.Object);
            Assert.True(single.IsValid());
        }
    }
}
