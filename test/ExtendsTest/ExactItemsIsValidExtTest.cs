﻿using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class ExactItemsIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_if_4_items_is_in_exact_4_valid()
        {
            ArrayValues array = new()
            {
                Int = new int[] { 1, 2, 3, 4 }
            };

            _notification.Clear();
            _notification.ExactItemsIsValid(array.Int, 4);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.ExactItemsIsValid(array, x => x.Int, 4);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(x => x.Int, 4);
            Assert.True(array.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(array.Int, 4);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_4_items_is_in_exact_5_invalid()
        {
            ArrayValues array = new()
            {
                Int = new int[] { 1, 2, 3, 4 }
            };

            _notification.Clear();
            _notification.ExactItemsIsValid(array.Int, 5);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.ExactItemsIsValid(array, x => x.Int, 5);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(x => x.Int, 5);
            Assert.False(array.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(array.Int, 5);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_if_6_items_is_in_exact_5_invalid()
        {
            ArrayValues array = new()
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            _notification.Clear();
            _notification.ExactItemsIsValid(array.Int, 5);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.ExactItemsIsValid(array, x => x.Int, 5);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(x => x.Int, 5);
            Assert.False(array.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(array.Int, 5);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_if_0_items_is_in_exact_5_ignore_valid()
        {
            ArrayValues array = new()
            {
                Int = Array.Empty<int>()
            };

            _notification.Clear();
            _notification.ExactItemsIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.ExactItemsIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(x => x.Int, 5);
            Assert.True(array.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(array.Int, 5);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_null_items_is_in_exact_5_invalid()
        {
            ArrayValues array = new()
            {
                Int = null
            };

            _notification.Clear();
            _notification.ExactItemsIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.ExactItemsIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(x => x.Int, 5);
            Assert.True(array.IsValid());

            array.Notifications.Clear();
            array.ExactItemsIsValid(array.Int, 5);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_if_exact_less_1_exception()
        {
            ArrayValues array = new()
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.ExactItemsIsValid(array.Int, 0));
            Assert.Throws<ArgumentException>(() => _notification.ExactItemsIsValid(array, x => x.Int, 0));
            Assert.Throws<ArgumentException>(() => array.ExactItemsIsValid(x => x.Int, 0));
            Assert.Throws<ArgumentException>(() => array.ExactItemsIsValid(array.Int, 0));
        }
    }
}
