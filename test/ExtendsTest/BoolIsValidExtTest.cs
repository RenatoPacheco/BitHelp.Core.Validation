using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BoolIsValidExtTest
    {
        readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null)]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData("True")]
        [InlineData("False")]
        [InlineData("true")]
        [InlineData("false")]
        public void Check_format_is_valid(object input)
        {
            SingleValues single = new()
            {
                Object = input
            };

            _notification.Clear();
            _notification.BoolIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(input);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("1")]
        public void Check_format_is_invalid(object input)
        {
            SingleValues single = new()
            {
                Object = input
            };

            _notification.Clear();
            _notification.BoolIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BoolIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(input);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BoolIsValid(x => x.Object);
            Assert.False(single.IsValid());
        }
    }
}
