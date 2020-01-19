using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxNumberIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_max_number_valid()
        {

            var single = new SingleValues
            {
                String = "123"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 123);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid<SingleValues>(single, x => x.String, 123);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_max_number_invalid()
        {

            var single = new SingleValues
            {
                String = "123"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 122);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid<SingleValues>(single, x => x.String, 122);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_not_number_invalid()
        {

            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 101);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid<SingleValues>(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_null_valid()
        {

            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 101);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid<SingleValues>(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
