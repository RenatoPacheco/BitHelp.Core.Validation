using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeItemsIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_6_items_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_5_items_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 110);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_10_items_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 110);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_4_items_is_in_range_5_and_10_invalid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4 }
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 10);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_if_0_items_is_in_range_5_and_10_ignore_valid()
        {
            var array = new ArrayValues
            {
                Int = Array.Empty<int>()
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_null_items_is_in_range_5_and_10_invalid()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            _notification.Clear();
            _notification.RangeItemsIsValid(array.Int, 5, 10);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RangeItemsIsValid(array, x => x.Int, 5, 10);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.RangeItemsIsValid(x => x.Int, 5, 10);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_minimum_less_1_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array.Int, 0, 10));
            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array, x => x.Int, 0, 10));
            Assert.Throws<ArgumentException>(() => array.RangeItemsIsValid(x => x.Int, 0, 10));
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array.Int, 5, 0));
            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array, x => x.Int, 5, 0));
            Assert.Throws<ArgumentException>(() => array.RangeItemsIsValid(x => x.Int, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array.Int, 5, 4));
            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array, x => x.Int, 5, 4));
            Assert.Throws<ArgumentException>(() => array.RangeItemsIsValid(x => x.Int, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array.Int, 5, 5));
            Assert.Throws<ArgumentException>(() => _notification.RangeItemsIsValid(array, x => x.Int, 5, 5));
            Assert.Throws<ArgumentException>(() => array.RangeItemsIsValid(x => x.Int, 5, 5));
        }
    }
}
