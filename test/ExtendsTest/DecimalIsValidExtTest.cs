using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DecimalIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Decimal = .121m
            };

            notification.Clear();
            notification.DecimalIsValid(single.Decimal);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.DecimalIsValid(single, x => x.Decimal);
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
            notification.DecimalIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.DecimalIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                DecimalNull = null
            };

            notification.Clear();
            notification.DecimalIsValid(single.DecimalNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.DecimalIsValid(single, x => x.DecimalNull);
            Assert.True(notification.IsValid());
        }
    }
}
