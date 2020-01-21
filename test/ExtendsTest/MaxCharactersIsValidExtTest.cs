using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxCharactersIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_max_characters_valid()
        {

            var single = new SingleValues
            {
                String = "MaxCharactersIsValid"
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, single.String.Length);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, single.String.Length);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_max_characters_invalid()
        {

            var single = new SingleValues
            {
                String = "MaxCharactersIsValid"
            };

            notification.Clear();
            notification.MaxCharactersIsValid(single.String, single.String.Length - 1);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, single.String.Length - 1);
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
            notification.MaxCharactersIsValid(single.String, 101);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.MaxCharactersIsValid(single, x => x.String, 10);
            Assert.True(notification.IsValid());
        }
    }
}
