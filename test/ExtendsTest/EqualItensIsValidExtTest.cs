﻿using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualItensIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_number_itens_is_valid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = new bool[] { true, false, true },
                Char = new char[] { 'a', 'b', 'c' }
            };

            _notification.Clear();
            _notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_number_itens_is_invalid()
        {
            ArrayValues array = new ArrayValues
            {
                Bool = new bool[] { true, false, true },
                Char = new char[] { 'a', 'b' }
            };

            _notification.Clear();
            _notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());
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
            _notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.True(_notification.IsValid());
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
            _notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());
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
            _notification.EqualItensIsValid(array.Bool, array.Char);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualItensIsValid(array, x => x.Bool, y => y.Char);
            Assert.False(_notification.IsValid());
        }
    }
}
