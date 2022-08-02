using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareLessNumberIsValidExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_all_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = null,
                DecimalNull = null
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = null
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = null,
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_less_valid()
        {
            SingleValues single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = 456
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_plus_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = 456.ToString(),
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CompareLessNumberIsValid(x => x.String, x => x.DecimalNull);
            Assert.False(single.IsValid());
        }
    }
}
