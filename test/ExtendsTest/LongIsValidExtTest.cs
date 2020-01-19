using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class LongIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Long = long.MaxValue
            };

            notification.Clear();
            notification.LongIsValid(single.Long);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.LongIsValid<SingleValues>(single, x => x.Long);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_not_number_is_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            notification.Clear();
            notification.LongIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.LongIsValid<SingleValues>(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                LongNull = null
            };

            notification.Clear();
            notification.LongIsValid(single.LongNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.LongIsValid<SingleValues>(single, x => x.LongNull);
            Assert.True(notification.IsValid());
        }
    }
}
