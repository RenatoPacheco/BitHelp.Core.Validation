using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EnumIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.DateTime
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Enum, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Enum, typeof(EnumValue));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_string_is_valid()
        {
            var single = new SingleValues
            {
                String = EnumValue.DateTime.ToString()
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_string_is_invalid()
        {
            var single = new SingleValues
            {
                String = "sometext"
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_number_is_valid()
        {
            var single = new SingleValues
            {
                Int = (int)EnumValue.DateTime
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Int, typeof(EnumValue));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_number_is_invalid()
        {
            var single = new SingleValues
            {
                Int = 100
            };

            _notification.Clear();
            _notification.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.Int, typeof(EnumValue));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EnumIsValid(single, x => x.String, typeof(EnumValue));
            Assert.True(_notification.IsValid());
        }
    }
}
