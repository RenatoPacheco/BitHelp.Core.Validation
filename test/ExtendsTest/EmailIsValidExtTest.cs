using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EmailIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_is_valid()
        {
            SingleValues single = new()
            {
                String = "myemail@site.com"
            };

            _notification.Clear();
            _notification.EmailIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EmailIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(x => x.String);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(single.String);
            Assert.True(single.IsValid());
        }


        [Fact]
        public void Check_is_invalid()
        {
            SingleValues single = new()
            {
                String = "myemailsite.com"
            };

            _notification.Clear();
            _notification.EmailIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EmailIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(x => x.String);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(single.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.EmailIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EmailIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(x => x.String);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.EmailIsValid(single.String);
            Assert.True(single.IsValid());
        }
    }
}
