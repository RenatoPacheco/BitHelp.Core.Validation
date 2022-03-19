using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CpfIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null)]
        [InlineData("153.179.966-35")]
        [InlineData("15317996635")]
        public void Check_format_is_valid(string input)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.CpfIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(input);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("153.179.966-00")]
        [InlineData("15317996600")]
        [InlineData("000.000.000-11")]
        public void Check_format_is_invalid(string input)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.CpfIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(input);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.String);
            Assert.False(single.IsValid());
        }
    }
}
