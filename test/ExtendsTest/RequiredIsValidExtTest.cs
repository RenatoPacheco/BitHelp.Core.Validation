using Xunit;
using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData("")]
        [InlineData(123)]
        [InlineData("abcd")]
        public void Check_value_is_valid(object value)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(null)]
        public void Check_value_not_is_valid(object value)
        {
            SingleValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.False(single.IsValid());
        }

        [Theory]
        [InlineData(123, 456)]
        [InlineData(123, "456")]
        [InlineData("", "")]
        public void Check_value_array_is_valid(params object[] value)
        {
            ArrayValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "abc")]
        public void Check_value_array_not_is_valid(params object[] value)
        {
            ArrayValues single = new()
            {
                Object = value
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_empty_array__not_is_valid()
        {
            ArrayValues single = new()
            {
                Object = Array.Empty<object>()
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_null_array_not_is_valid()
        {
            ArrayValues single = new()
            {
                Object = null
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(x => x.Object);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.RequiredIsValid(single.Object);
            Assert.False(single.IsValid());
        }
    }
}
