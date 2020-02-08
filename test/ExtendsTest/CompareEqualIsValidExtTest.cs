using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CompareEqualIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_equal_valid()
        {
            var single = new SingleValues
            {
                LongNull = 123,
                Long = 123
            };

            _notification.Clear();
            _notification.CompareEqualIsValid(single, x => x.LongNull, x => x.Long);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_different_invalid()
        {
            var single = new SingleValues
            {
                LongNull = 234,
                Long = 123
            };

            _notification.Clear();
            _notification.CompareEqualIsValid(single, x => x.LongNull, x => x.Long);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_equal_type_different_valid()
        {
            var single = new SingleValues
            {
                String = "234",
                Long = 234
            };

            _notification.Clear();
            _notification.CompareEqualIsValid(single, x => x.String, x => x.Long);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                LongNull = null,
                Long = 123
            };

            _notification.Clear();
            _notification.CompareEqualIsValid(single, x => x.LongNull, x => x.Long);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_different_case_invalid()
        {
            var single = new SingleValues
            {
                String = "TrUe",
                Bool = true
            };

            _notification.Clear();
            _notification.CompareEqualIsValid(single, x => x.String, x => x.Bool);
            Assert.False(_notification.IsValid());
        }
    }
}
