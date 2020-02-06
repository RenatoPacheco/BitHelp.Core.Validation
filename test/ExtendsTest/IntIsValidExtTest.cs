using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class IntIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Int = 123
            };

            _notification.Clear();
            _notification.IntIsValid(single.Int);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.Int);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_not_number_is_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.IntIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                IntNull = null
            };

            _notification.Clear();
            _notification.IntIsValid(single.IntNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.IntIsValid(single, x => x.IntNull);
            Assert.True(_notification.IsValid());
        }
    }
}
