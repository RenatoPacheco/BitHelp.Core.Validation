using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using System.Collections;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualItemsIsValidExtTest
    {
        readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, null)]
        [InlineData(new string[] { }, new int[] { })]
        [InlineData(new bool[] { true, false, true }, new char[] { 'a', 'b', 'c' })]
        public void Check_format_is_valid(IList input, IList compare)
        {
            ArrayValues lists = new()
            {
                Value = input,
                Compare = compare
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists.Value, lists.Compare);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists.Value, lists.Compare, lists.Compare);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists, x => x.Value, x => x.Compare);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists, x => x.Value, x => x.Compare, x => x.Compare);
            Assert.True(_notification.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(input, compare);
            Assert.True(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(input, compare, compare);
            Assert.True(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(
                x => x.Value, x => x.Compare);
            Assert.True(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(
                x => x.Value, x => x.Compare, x => x.Compare);
            Assert.True(lists.IsValid());
        }

        [Theory]
        [InlineData(null, new char[] { 'a', 'b', 'c' })]
        [InlineData(new bool[] { true, false, true }, new string[] { "a", "b" })]
        [InlineData(new bool[] { true, false, true }, null)]
        [InlineData(new bool[] { }, null)]
        public void Check_format_is_invalid(IList input, IList compare)
        {
            ArrayValues lists = new()
            {
                Value = input,
                Compare = compare
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists.Value, lists.Compare);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists.Value, lists.Compare, lists.Compare);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists, x => x.Value, x => x.Compare);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(
                lists, x => x.Value, x => x.Compare, x => x.Compare);
            Assert.False(_notification.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(input, compare);
            Assert.False(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(input, compare, compare);
            Assert.False(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(
                x => x.Value, x => x.Compare);
            Assert.False(lists.IsValid());

            lists.Notifications.Clear();
            lists.EqualItemsIsValid(
                x => x.Value, x => x.Compare, x => x.Compare);
            Assert.False(lists.IsValid());
        }
    }
}
