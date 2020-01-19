using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class IntIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Int = 123
            };

            notification.Clear();
            notification.IntIsValid(single.Int);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.IntIsValid<SingleValues>(single, x => x.Int);
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
            notification.IntIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.IntIsValid<SingleValues>(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                IntNull = null
            };

            notification.Clear();
            notification.IntIsValid(single.IntNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.IntIsValid<SingleValues>(single, x => x.IntNull);
            Assert.True(notification.IsValid());
        }
    }
}
