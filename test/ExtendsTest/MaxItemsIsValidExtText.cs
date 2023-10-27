using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxItemsIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, 1)]
        [InlineData(new string[] { }, 1)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 4 }, 4)]
        [InlineData(new object[] { 1, "text", true, null }, 5)]
        public void Check_max_items_is_valid(IEnumerable input, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.MaxItemsIsValid(array.Value, max);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItemsIsValid(array, x => x.Value, max);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.MaxItemsIsValid(x => x.Value, max);
            Assert.True(array.IsValid());

            array.Notifications.Clear();
            array.MaxItemsIsValid(array.Value, max);
            Assert.True(array.IsValid());
        }

        [Theory]
        [InlineData(new object[] { 1, "text", true, null }, 3)]
        public void Check_max_items_is_invalid(IEnumerable input, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.MaxItemsIsValid(array.Value, max);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItemsIsValid(array, x => x.Value, max);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.MaxItemsIsValid(x => x.Value, max);
            Assert.False(array.IsValid());

            array.Notifications.Clear();
            array.MaxItemsIsValid(array.Value, max);
            Assert.False(array.IsValid());
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(null, -1)]
        [InlineData(new string[] { }, -2)]
        [InlineData(new string[] { "text" }, -3)]
        public void Check_max_items_exception(IEnumerable input, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            Assert.Throws<ArgumentException>(() => _notification.MaxItemsIsValid(array.Value, max));
            Assert.Throws<ArgumentException>(() => _notification.MaxItemsIsValid(array, x => x.Value, max));
            Assert.Throws<ArgumentException>(() => array.MaxItemsIsValid(x => x.Value, max));
            Assert.Throws<ArgumentException>(() => array.MaxItemsIsValid(array.Value, max));
        }
    }
}
