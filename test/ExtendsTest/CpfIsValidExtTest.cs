using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CpfIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                String = "222.704.930-87"
            };

            _notification.Clear();
            _notification.CpfIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.String);
            Assert.True(single.IsValid());
        }


        [Fact]
        public void Check_is_invalid()
        {
            var single = new SingleValues
            {
                String = "222.704.930-00"
            };

            _notification.Clear();
            _notification.CpfIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.CpfIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.String);
            Assert.True(single.IsValid());
        }
    }
}
