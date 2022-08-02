using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class UrlIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_simple_url_https_valid()
        {
            SingleValues single = new()
            {
                String = "https://www.site.com"
            };

            _notification.Clear();
            _notification.UrlIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.UrlIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.UrlIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_simple_url_http_valid()
        {
            SingleValues single = new()
            {
                String = "http://site.com"
            };

            _notification.Clear();
            _notification.UrlIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.UrlIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.UrlIsValid(x => x.String);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_error_in_start_url_invalid()
        {
            SingleValues single = new()
            {
                String = "htt://site.com"
            };

            _notification.Clear();
            _notification.UrlIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.UrlIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.UrlIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ftp_invalid()
        {
            SingleValues single = new()
            {
                String = "ftp://site.com"
            };

            _notification.Clear();
            _notification.UrlIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.UrlIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.UrlIsValid(x => x.String);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.UrlIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.UrlIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.UrlIsValid(x => x.String);
            Assert.True(single.IsValid());
        }
    }
}
