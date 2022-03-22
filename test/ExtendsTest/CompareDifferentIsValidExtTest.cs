using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareDifferentIsValidExtTest
    {
        readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, 100)]
        [InlineData(100, null)]
        [InlineData(123, 321)]
        [InlineData(123, "123,9")]
        [InlineData(true, "trUe")]
        public void Check_format_is_valid(object input, object compare)
        {
            SingleValues single = new()
            {
                Object = input,
                Compare = compare
            };

            _notification.Clear();
            _notification.CompareDifferentIsValid(
                single, x => x.Object, x => x.Compare);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareDifferentIsValid(
                x => x.Object, x => x.Compare);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(123, 123)]
        [InlineData(123, "123")]
        public void Check_format_is_invalid(object input, object compare)
        {
            SingleValues single = new()
            {
                Object = input,
                Compare = compare
            };

            _notification.Clear();
            _notification.CompareDifferentIsValid(
                single, x => x.Object, x => x.Compare);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareDifferentIsValid(
                x => x.Object, x => x.Compare);
            Assert.False(single.IsValid());
        }
    }
}
