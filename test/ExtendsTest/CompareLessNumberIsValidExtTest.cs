using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareLessNumberIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_all_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                DecimalNull = null
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            var single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = null
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_value_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_value_less_valid()
        {
            var single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = 456
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            var single = new SingleValues
            {
                String = 123.ToString(),
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_value_plus_invalid()
        {
            var single = new SingleValues
            {
                String = 456.ToString(),
                DecimalNull = 123
            };

            _notification.Clear();
            _notification.CompareLessNumberIsValid(single, x => x.String, x => x.DecimalNull);
            Assert.False(_notification.IsValid());
        }
    }
}
