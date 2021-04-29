using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class UrlIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_simple_url_https_valid()
        {
            var single = new SingleValues
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
            var single = new SingleValues
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
            var single = new SingleValues
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
            var single = new SingleValues
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
            var single = new SingleValues
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
