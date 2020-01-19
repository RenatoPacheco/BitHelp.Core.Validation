
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EnumIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                Enum = EnumValue.DateTime
            };

            notification.Clear();
            notification.EnumIsValid(single.Enum, typeof(EnumValue));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EnumIsValid<SingleValues>(single, x => x.Enum, typeof(EnumValue));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_string_is_valid()
        {
            var single = new SingleValues
            {
                String = EnumValue.DateTime.ToString()
            };

            notification.Clear();
            notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EnumIsValid<SingleValues>(single, x => x.String, typeof(EnumValue));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_string_is_invalid()
        {
            var single = new SingleValues
            {
                String = "sometext"
            };

            notification.Clear();
            notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.EnumIsValid<SingleValues>(single, x => x.String, typeof(EnumValue));
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_number_is_valid()
        {
            var single = new SingleValues
            {
                Int = (int)EnumValue.DateTime
            };

            notification.Clear();
            notification.EnumIsValid(single.Int, typeof(EnumValue));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EnumIsValid<SingleValues>(single, x => x.Int, typeof(EnumValue));
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.EnumIsValid(single.String, typeof(EnumValue));
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EnumIsValid<SingleValues>(single, x => x.String, typeof(EnumValue));
            Assert.True(notification.IsValid());
        }
    }
}
