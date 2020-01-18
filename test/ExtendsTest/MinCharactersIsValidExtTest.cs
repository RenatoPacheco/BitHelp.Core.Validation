using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MinCharactersIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_min_characters_valid()
        {

            var single = new SingleValues
            {
                String = "MinCharactersIsValid"
            };

            notification.Clear();
            notification.MinCharactersIsValid(single.String, single.String.Length);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinCharactersIsValid<SingleValues>(single, x => x.String, single.String.Length);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_min_characters_invalid()
        {

            var single = new SingleValues
            {
                String = "MinCharactersIsValid"
            };

            notification.Clear();
            notification.MinCharactersIsValid(single.String, single.String.Length + 1);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MinCharactersIsValid<SingleValues>(single, x => x.String, single.String.Length + 1);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_null_valid()
        {

            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.MinCharactersIsValid(single.String, 101);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MinCharactersIsValid<SingleValues>(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
