using Xunit;
using System.Globalization;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareLessDateTimeIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "12/25/2020")]
        [InlineData("12/24/2020", null)]
        [InlineData("12/24/2020", "12/25/2020")]
        [InlineData("24/12/2020", "25/12/2020", "pt-BR")]
        [InlineData("not valid date", "12/25/2020")]
        [InlineData("12/24/2020", "not valid date")]
        [InlineData("not valid date", "not valid date", null)]
        public void Check_format_is_valid(
            object input, object compare, string cultureInfo = "en-US")
        {
            SingleValues single = new()
            {
                Value = input,
                Compare = compare
            };

            CultureInfo culture = cultureInfo is null
                ? null : new(cultureInfo);

            _notification.Clear();
            _notification.CompareLessDateTimeIsValid(
                single, x => x.Value, x => x.Compare, culture);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessDateTimeIsValid(
                x => x.Value, x => x.Compare, culture);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("12/25/2020", "12/24/2020")]
        [InlineData("25/12/2020", "24/12/2020", "pt-BR")]
        public void Check_format_is_invalid(
            object input, object compare, string cultureInfo = "en-US")
        {
            SingleValues single = new()
            {
                Value = input,
                Compare = compare
            };

            CultureInfo culture = cultureInfo is null
                ? null : new(cultureInfo);

            _notification.Clear();
            _notification.CompareLessDateTimeIsValid(
                single, x => x.Value, x => x.Compare, culture);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessDateTimeIsValid(
                x => x.Value, x => x.Compare, culture);
            Assert.False(single.IsValid());
        }

    }
}