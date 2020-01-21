using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System.Linq;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxNumberItensIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_max_exact_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            notification.Clear();
            notification.MaxNumberItensIsValid(array.Int, array.Int.Count());
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberItensIsValid(array, x => x.Int, array.Int.Count());
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_max_less_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            notification.Clear();
            notification.MaxNumberItensIsValid(array.Int, array.Int.Count() + 1);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberItensIsValid(array, x => x.Int, array.Int.Count() + 1);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_max_plus_invalid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { 1, 2, 3, 4, 5 }
            };

            notification.Clear();
            notification.MaxNumberItensIsValid(array.Int, array.Int.Count() - 1);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberItensIsValid(array, x => x.Int, array.Int.Count() - 1);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_empty_itens_valid()
        {
            var array = new ArrayValues
            {
                Int = new int[] { }
            };

            notification.Clear();
            notification.MaxNumberItensIsValid(array.Int, array.Int.Count() + 1);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberItensIsValid(array, x => x.Int, array.Int.Count() + 1);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_null_valid()
        {
            var array = new ArrayValues
            {
                Int = null
            };

            notification.Clear();
            notification.MaxNumberItensIsValid(array.Int, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberItensIsValid(array, x => x.Int, 10);
            Assert.True(notification.IsValid());
        }
    }
}
