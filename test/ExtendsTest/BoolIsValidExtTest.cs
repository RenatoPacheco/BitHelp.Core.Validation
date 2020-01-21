using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BoolIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_true_is_valid()
        {
            var single = new SingleValues
            {
                Bool = true
            };

            notification.Clear();
            notification.BoolIsValid(single.Bool);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BoolIsValid(single, x => x.Bool);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_true_as_string_is_valid()
        {
            var single = new SingleValues
            {
                String = "true"
            };

            notification.Clear();
            notification.BoolIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BoolIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.BoolIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.BoolIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_number_is_invalid()
        {
            var single = new SingleValues
            {
                String = "1"
            };

            notification.Clear();
            notification.BoolIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.BoolIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }
    }
}
