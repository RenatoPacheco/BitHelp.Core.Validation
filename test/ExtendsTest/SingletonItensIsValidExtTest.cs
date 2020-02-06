using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SingletonItensIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_list_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", "2", "3", null }
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_list_repeat_is_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", "2", "1", null }
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_list_repeat_null_is_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", null, "3", null }
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_one_item_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1" }
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_empty_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { }
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_null_is_valid()
        {
            var array = new ArrayValues
            {
                String = null
            };

            notification.Clear();
            notification.SingletonItensIsValid(array.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(notification.IsValid());
        }
    }
}
