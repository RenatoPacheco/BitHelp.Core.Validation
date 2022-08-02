using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System.Globalization;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DateTimeIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, "en-US")]
        [InlineData("12/22/2020", "en-US")]
        [InlineData("22/12/2020", "pt-BR")]
        public void Date_time_is_valid(string input, string cultureInfo)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new CultureInfo(cultureInfo));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new CultureInfo(cultureInfo));
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(x => x.String, new CultureInfo(cultureInfo));
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(single.String, new CultureInfo(cultureInfo));
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("22/12/2020", "en-US")]
        [InlineData("12/22/2020", "pt-BR")]
        public void Date_time_not_is_valid(string input, string cultureInfo)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new CultureInfo(cultureInfo));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new CultureInfo(cultureInfo));
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(x => x.String, new CultureInfo(cultureInfo));
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.DateTimeIsValid(single.String, new CultureInfo(cultureInfo));
            Assert.False(single.IsValid());
        }
    }
}
