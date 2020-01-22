﻿using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeNumberItensIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_6_itens_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_5_itens_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 110);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_itens_is_in_range_5_and_10_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 110);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_4_itens_is_in_range_5_and_10_invalid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4 }
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_0_itens_is_in_range_5_and_10_invalid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { }
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_null_itens_is_in_range_5_and_10_invalid()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            notification.Clear();
            notification.RangeNumberItensIsValid(array.Int, 5, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberItensIsValid(array, x => x.Int, 5, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_minimum_less_1_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array.Int, 0, 10));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array, x => x.Int, 0, 10));
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array.Int, 5, 0));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array, x => x.Int, 5, 0));
        }

        [Fact]
        public void Check_if_maximum_less_minimum_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array.Int, 5, 4));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array, x => x.Int, 5, 4));
        }

        [Fact]
        public void Check_if_maximum_equal_minimum_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array.Int, 5, 5));
            Assert.Throws<ArgumentException>(() => notification.RangeNumberItensIsValid(array, x => x.Int, 5, 5));
        }
    }
}