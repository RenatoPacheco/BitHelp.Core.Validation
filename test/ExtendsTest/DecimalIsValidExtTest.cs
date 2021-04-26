using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DecimalIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Decimal = .121m
            };

            _notification.Clear();
            _notification.DecimalIsValid(single.Decimal);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DecimalIsValid(single, x => x.Decimal);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DecimalIsValid(x => x.Decimal);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_not_number_is_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.DecimalIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.DecimalIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.DecimalIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                DecimalNull = null
            };

            _notification.Clear();
            _notification.DecimalIsValid(single.DecimalNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DecimalIsValid(single, x => x.DecimalNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DecimalIsValid(x => x.DecimalNull);
            Assert.True(single.IsValid());
        }
    }
}
