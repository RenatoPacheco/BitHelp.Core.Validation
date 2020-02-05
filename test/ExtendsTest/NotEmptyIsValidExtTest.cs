using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class NotEmptyIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_no_empty_valid()
        {
            var single = new SingleValues
            {
                String = "123"
            };

            notification.Clear();
            notification.NotEmptyIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            notification.Clear();
            notification.NotEmptyIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.NotEmptyIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.NotEmptyIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_with_space_valid()
        {
            var single = new SingleValues
            {
                String = "     "
            };

            notification.Clear();
            notification.NotEmptyIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }
    }
}
