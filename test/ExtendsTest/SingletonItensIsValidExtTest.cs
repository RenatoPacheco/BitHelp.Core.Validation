using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SingletonItensIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_list_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", "2", "3", null }
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_list_repeat_is_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", "2", "1", null }
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_list_repeat_null_is_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1", null, "3", null }
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_one_item_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { "1" }
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_empty_is_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { }
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_null_is_valid()
        {
            var array = new ArrayValues
            {
                String = null
            };

            _notification.Clear();
            _notification.SingletonItensIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.SingletonItensIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());
        }
    }
}
