﻿using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualItensIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_number_itens_is_valid()
        {
            ArrayValues array = new ArrayValues();
            array.Bool = new bool[] { true, false, true };
            array.Char = new char[] { 'a', 'b', 'c' };

            notification.Clear();
            this.notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.True(notification.IsValid());

            notification.Clear();
            this.notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_number_itens_is_invalid()
        {
            ArrayValues array = new ArrayValues();
            array.Bool = new bool[] { true, false, true };
            array.Char = new char[] { 'a', 'b' };

            notification.Clear();
            this.notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(notification.IsValid());

            notification.Clear();
            this.notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_all_values_null_is_valid()
        {
            ArrayValues array = new ArrayValues();
            array.Bool = null;
            array.Char = null;

            notification.Clear();
            this.notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.True(notification.IsValid());

            notification.Clear();
            this.notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_one_value_null_is_invalid()
        {
            ArrayValues array = new ArrayValues();
            array.Bool = new bool[] { true, false, true };
            array.Char = null;

            notification.Clear();
            this.notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(notification.IsValid());

            notification.Clear();
            this.notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_one_value_null_and_other_empty_is_invalid()
        {
            ArrayValues array = new ArrayValues();
            array.Bool = new bool[] { };
            array.Char = null;

            notification.Clear();
            this.notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(notification.IsValid());

            notification.Clear();
            this.notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(notification.IsValid());
        }
    }
}