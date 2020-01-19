

using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EmailIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_is_valid()
        {
            var single = new SingleValues
            {
                String = "myemail@site.com"
            };

            notification.Clear();
            notification.EmailIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EmailIsValid<SingleValues>(single, x => x.String);
            Assert.True(notification.IsValid());
        }


        [Fact]
        public void Check_is_invalid()
        {
            var single = new SingleValues
            {
                String = "myemailsite.com"
            };

            notification.Clear();
            notification.EmailIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.EmailIsValid<SingleValues>(single, x => x.String);
            Assert.False(notification.IsValid());
        }
        
        [Fact]
        public void Check_ignore_null()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.EmailIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EmailIsValid<SingleValues>(single, x => x.String);
            Assert.True(notification.IsValid());
        }
    }
}
