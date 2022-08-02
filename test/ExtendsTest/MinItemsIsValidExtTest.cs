using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinItemsIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, 4)]
        [InlineData(new string[] { }, 5)]
        [InlineData(new object[] { 2, "text", true }, 3)]
        [InlineData(new object[] { 3, "text", false }, 2)]
        public void Check_min_items_is_valid(IEnumerable input, int min)
        {
            ArrayValues array = new ArrayValues
            {
                Value = input
            };

            _notification.Clear();
            _notification.MinItemsIsValid(array.Value, min);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MinItemsIsValid(array, x => x.Value, min);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.MinItemsIsValid(x => x.Value, min);
            Assert.True(array.IsValid());
        }

        [Theory]
        [InlineData(new object[] { null }, 3)]
        [InlineData(new object[] { 1, "text" }, 3)]
        public void Check_min_items_is_invalid(IEnumerable input, int min)
        {
            ArrayValues array = new ArrayValues
            {
                Value = input
            };

            _notification.Clear();
            _notification.MinItemsIsValid(array.Value, min);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MinItemsIsValid(array, x => x.Value, min);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.MinItemsIsValid(x => x.Value, min);
            Assert.False(array.IsValid());
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(null, -1)]
        [InlineData(new string[] { }, -2)]
        [InlineData(new string[] { "text" }, -3)]
        public void Check_min_items_exception(IEnumerable input, int min)
        {
            ArrayValues array = new ArrayValues
            {
                Value = input
            };

            Assert.Throws<ArgumentException>(() => _notification.MinItemsIsValid(array.Value, min));
            Assert.Throws<ArgumentException>(() => _notification.MinItemsIsValid(array, x => x.Value, min));
            Assert.Throws<ArgumentException>(() => array.MinItemsIsValid(x => x.Value, min));
        }
    }
}
