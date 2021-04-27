using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualItemsIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_number_items_is_valid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = new bool[] { true, false, true },
                Char = new char[] { 'a', 'b', 'c' }
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(array.Bool, array.Char);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.EqualItemsIsValid(x => x.Bool, y => y.Char);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_number_items_is_invalid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = new bool[] { true, false, true },
                Char = new char[] { 'a', 'b' }
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.EqualItemsIsValid(x => x.Bool, y => y.Char);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_all_values_null_is_valid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = null,
                Char = null
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(array.Bool, array.Char);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(_notification.IsValid());

            array.Notifications.Clear();
            array.EqualItemsIsValid(x => x.Bool, y => y.Char);
            Assert.True(array.IsValid());
        }

        [Fact]
        public void Check_one_value_null_is_invalid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = new bool[] { true, false, true },
                Char = null
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.EqualItemsIsValid(x => x.Bool, y => y.Char);
            Assert.False(array.IsValid());
        }

        [Fact]
        public void Check_one_value_null_and_other_empty_is_invalid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = Array.Empty<bool>(),
                Char = null
            };

            _notification.Clear();
            _notification.EqualItemsIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItemsIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());

            array.Notifications.Clear();
            array.EqualItemsIsValid(x => x.Bool, y => y.Char);
            Assert.False(array.IsValid());
        }
    }
}
