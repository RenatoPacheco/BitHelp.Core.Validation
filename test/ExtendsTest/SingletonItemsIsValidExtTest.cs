﻿using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System.Collections;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SingletonItemsIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, null)]
        [InlineData(new string[] { }, null)]
        [InlineData(new object[] { 2, "text", true }, null)]
        [InlineData(new object[] { 2, "text", true, false }, null)]
        [InlineData(new object[] { 2, "2", true }, null)]
        [InlineData(new object[] { 2, "2", true, null }, null)]
        [InlineData(new object[] { null, null, true, 2, "text" }, null)]
        public void Check_singleton_items_is_valid(IEnumerable input, object any)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.SingletonItemsIsValid(array.Value);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItemsIsValid(array, x => x.Value);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.SingletonItemsIsValid(x => x.Value);
            Assert.True(array.IsValid());

            array.Notifications.Clear();
            array.SingletonItemsIsValid(array.Value);
            Assert.True(array.IsValid());

            Assert.Null(any);
        }

        [Theory]
        [InlineData(new object[] { 2, "text", true, true }, null)]
        [InlineData(new object[] { 2, "text", "text" }, null)]
        [InlineData(new object[] { 2, 2, "text" }, null)]
        [InlineData(new object[] { null, null, 2, 2, "text" }, null)]
        public void Check_singleton_items_is_invalid(IEnumerable input, object any)
        {
            ArrayValues array = new()
            {
                Value = input
            };

            _notification.Clear();
            _notification.SingletonItemsIsValid(array.Value);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItemsIsValid(array, x => x.Value);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.SingletonItemsIsValid(x => x.Value);
            Assert.False(array.IsValid());

            array.Notifications.Clear();
            array.SingletonItemsIsValid(array.Value);
            Assert.False(array.IsValid());

            Assert.Null(any);
        }
    }
}
