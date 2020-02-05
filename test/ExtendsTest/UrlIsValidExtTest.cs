using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class UrlIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_simple_url_https_valid()
        {
            var single = new SingleValues
            {
                String = "https://www.site.com"
            };

            notification.Clear();
            notification.UrlIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.UrlIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_simple_url_http_valid()
        {
            var single = new SingleValues
            {
                String = "http://site.com"
            };

            notification.Clear();
            notification.UrlIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.UrlIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_error_in_start_url_invalid()
        {
            var single = new SingleValues
            {
                String = "htt://site.com"
            };

            notification.Clear();
            notification.UrlIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.UrlIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ftp_invalid()
        {
            var single = new SingleValues
            {
                String = "ftp://site.com"
            };

            notification.Clear();
            notification.UrlIsValid(single.String);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.UrlIsValid(single, x => x.String);
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_null_valid()
        {
            var single = new SingleValues
            {
                String = null
            };

            notification.Clear();
            notification.UrlIsValid(single.String);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.UrlIsValid(single, x => x.String);
            Assert.True(notification.IsValid());
        }
    }
}
