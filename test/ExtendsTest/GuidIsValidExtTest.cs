using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class GuidIsValidExtTest
    {
        ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_guid_valid()
        {
            var single = new SingleValues();
            single.String = "3b8e6bc1-82eb-4339-998c-5f1fba019ae7";

            notification.Clear();
            notification.GuidIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.GuidIsValid<SingleValues>(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_empty_guid_valid()
        {
            var single = new SingleValues();
            single.String = "00000000-0000-0000-0000-000000000000";

            notification.Clear();
            notification.GuidIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.GuidIsValid<SingleValues>(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_empty_is_invalid()
        {
            var single = new SingleValues();
            single.String = string.Empty;

            notification.Clear();
            notification.GuidIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.GuidIsValid<SingleValues>(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_null_is_valid()
        {
            var single = new SingleValues();
            single.String = null;

            notification.Clear();
            notification.GuidIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.GuidIsValid<SingleValues>(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_value_invalid()
        {
            var single = new SingleValues();
            single.String = "3b8e6bc1-ghij-klmn-opqr-5f1fba019ae7";

            notification.Clear();
            notification.GuidIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.GuidIsValid<SingleValues>(single, x => x.String);
            Assert.False(notification.IsValid());
        }
    }
}
