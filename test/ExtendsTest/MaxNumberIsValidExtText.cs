using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxNumberIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = "5"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = "10"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            var single = new SingleValues
            {
                String = "11"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.MaxNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
