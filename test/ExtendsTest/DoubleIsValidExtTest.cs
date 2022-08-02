using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DoubleIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_is_valid()
        {
            SingleValues single = new()
            {
                Double = 1.79
            };

            _notification.Clear();
            _notification.DoubleIsValid(single.Double);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DoubleIsValid(single, x => x.Double);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DoubleIsValid(x => x.Double);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_not_number_is_invalid()
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.DoubleIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.DoubleIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.DoubleIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            SingleValues single = new()
            {
                DoubleNull = null
            };

            _notification.Clear();
            _notification.DoubleIsValid(single.DoubleNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DoubleIsValid(single, x => x.DoubleNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DoubleIsValid(x => x.DoubleNull);
            Assert.True(single.IsValid());
        }
    }
}
