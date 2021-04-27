using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class LongIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Long = long.MaxValue
            };

            _notification.Clear();
            _notification.LongIsValid(single.Long);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.LongIsValid(single, x => x.Long);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.LongIsValid(x => x.Long);
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
            _notification.LongIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.LongIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                LongNull = null
            };

            _notification.Clear();
            _notification.LongIsValid(single.LongNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.LongIsValid(single, x => x.LongNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.LongIsValid(x => x.LongNull);
            Assert.True(single.IsValid());
        }
    }
}
