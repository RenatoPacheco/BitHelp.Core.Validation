using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RangeNumberIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_ranger_10_between_20_at_15_valid()
        {
            var single = new SingleValues
            {
                Int = 15
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid<SingleValues>(single, x => x.Int, 10, 20);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ranger_10_between_20_at_30_invalid()
        {
            var single = new SingleValues
            {
                Int = 30
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid<SingleValues>(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ranger_10_between_20_at_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid<SingleValues>(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ranger_10_between_20_at_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid<SingleValues>(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ranger_10_between_20_at_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.RangeNumberIsValid(single.Int, 10, 20);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RangeNumberIsValid<SingleValues>(single, x => x.Int, 10, 20);
            Assert.False(notification.IsValid());
        }
    }
}
