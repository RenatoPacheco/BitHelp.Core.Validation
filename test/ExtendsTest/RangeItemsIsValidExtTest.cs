using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeItemsIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, 2, 3)]
        [InlineData(new object[] { }, 2, 3)]
        [InlineData(new object[] { 1, 2 }, 2, 3)]
        [InlineData(new object[] { 1, 2, 3 }, 2, 3)]
        public void Check_range_items_is_valid(IEnumerable input, int min, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Value, min, max);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Value, min, max);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Value, min, max);
            Assert.True(array.IsValid());
        }

        [Theory]
        [InlineData(new object[] { 1 }, 2, 3)]
        [InlineData(new object[] { 1, 2, 3, 4 }, 2, 3)]
        public void Check_range_items_is_invalid(IEnumerable input, int min, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Value, min, max);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Value, min, max);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Value, min, max);
            Assert.False(array.IsValid());
        }

        [Theory]
        [InlineData(null, 0, 3)]
        [InlineData(null, -1, 3)]
        [InlineData(null, 2, 0)]
        [InlineData(null, 2, -1)]
        [InlineData(null, 2, 1)]
        [InlineData(new string[] { }, 0, 3)]
        [InlineData(new string[] { }, -1, 3)]
        [InlineData(new string[] { }, 2, 0)]
        [InlineData(new string[] { }, 2, -1)]
        [InlineData(new string[] { }, 2, 1)]
        [InlineData(new string[] { "text" }, 0, 3)]
        [InlineData(new string[] { "text" }, -1, 3)]
        [InlineData(new string[] { "text" }, 2, 0)]
        [InlineData(new string[] { "text" }, 2, -1)]
        [InlineData(new string[] { "text" }, 2, 1)]
        public void Check_range_items_exception(IEnumerable input, int min, int max)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array.Value, min, max));
            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array, x => x.Value, min, max));
            Assert.Throws<ArgumentException>(() => array.RangeItemsIsValid(x => x.Value, min, max));
        }
    }
}
