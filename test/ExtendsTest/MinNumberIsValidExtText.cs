using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinNumberIsValidExtText
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_if_15_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = "15"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_minimum_10_valid()
        {

            var single = new SingleValues
            {
                String = "10"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_if_9_is_in_minimum_10_invalid()
        {

            var single = new SingleValues
            {
                String = "9"
            };

            notification.Clear();
            notification.MinNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
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
            notification.MinNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
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
            notification.MinNumberIsValid(single.String, 10);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
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
            notification.MinNumberIsValid(single.String, 10);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinNumberIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
