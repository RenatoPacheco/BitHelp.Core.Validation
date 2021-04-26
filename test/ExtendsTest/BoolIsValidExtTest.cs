using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BoolIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_true_is_valid()
        {
            var single = new SingleValues
            {
                Bool = true
            };

            _notification.Clear();
            _notification.BoolIsValid(single.Bool);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.Bool);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.Bool);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_true_as_string_is_valid()
        {
            var single = new SingleValues
            {
                String = "true"
            };

            _notification.Clear();
            _notification.BoolIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.BoolIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_number_is_invalid()
        {
            var single = new SingleValues
            {
                String = "1"
            };

            _notification.Clear();
            _notification.BoolIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.String);
            Assert.False(single.IsValid());
        }
    }
}
