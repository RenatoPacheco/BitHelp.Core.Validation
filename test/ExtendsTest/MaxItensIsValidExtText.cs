using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxItensIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_if_4_itens_is_in_maximum_5_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4 }
            };

            _notification.Clear();
            _notification.MaxItensIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItensIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_5_itens_is_in_maximum_5_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            _notification.Clear();
            _notification.MaxItensIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItensIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_6_itens_is_in_maximum_5_invalid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            _notification.Clear();
            _notification.MaxItensIsValid(array.Int, 5);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItensIsValid(array, x => x.Int, 5);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_0_itens_is_in_maximum_5_valid()
        {
            var array = new ArrayValues
            {
                Int = Array.Empty<int>()
            };

            _notification.Clear();
            _notification.MaxItensIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItensIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_null_itens_is_in_maximum_5_invalid()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            _notification.Clear();
            _notification.MaxItensIsValid(array.Int, 5);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxItensIsValid(array, x => x.Int, 5);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_maximum_less_1_exception()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            Assert.Throws<ArgumentException>(() => _notification.MaxItensIsValid(array.Int, 0));
            Assert.Throws<ArgumentException>(() => _notification.MaxItensIsValid(array, x => x.Int, 0));
        }
    }
}
