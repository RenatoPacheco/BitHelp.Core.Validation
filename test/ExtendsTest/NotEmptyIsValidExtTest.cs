using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class NotEmptyIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_no_empty_valid()
        {
            var single = new SingleValues
            {
                String = "123"
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_empty_ignore_with_space_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String, true);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String, true);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_with_space_invalid()
        {
            var single = new SingleValues
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_with_space_and_ignore_valid()
        {
            var single = new SingleValues
            {
                String = "     "
            };

            _notification.Clear();
            _notification.NotEmptyIsValid(single.String, true);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.NotEmptyIsValid(single, x => x.String, true);
            Assert.True(_notification.IsValid());
        }
    }
}
