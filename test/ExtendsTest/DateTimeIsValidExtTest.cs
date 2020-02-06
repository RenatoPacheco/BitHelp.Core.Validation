using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System.Globalization;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class DateTimeIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_date_en_US_valid()
        {
            var single = new SingleValues
            {
                String = "12/22/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new CultureInfo("en-US"));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new CultureInfo("en-US"));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_date_en_US_Invalid()
        {
            var single = new SingleValues
            {
                String = "22/12/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new CultureInfo("en-US"));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new CultureInfo("en-US"));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_date_pt_BR_valid()
        {
            var single = new SingleValues
            {
                String = "22/12/2020"
            };

            _notification.Clear();
            _notification.DateTimeIsValid(single.String, new CultureInfo("pt-BR"));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.DateTimeIsValid(single, x => x.String, new CultureInfo("pt-BR"));
            Assert.True(_notification.IsValid());
        }
    }
}
