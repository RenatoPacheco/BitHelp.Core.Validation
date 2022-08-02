using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System.Text.RegularExpressions;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RegexIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Theory]
        [InlineData(null, @"^[a-z]+$")]
        [InlineData("abcdfg", @"^[a-z]+$")]
        [InlineData("AbCdFg", @"^[a-z]+$", RegexOptions.IgnoreCase)]

        public void Regex_is_valid(string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.RegexIsValid(single.String, pattern, options);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RegexIsValid(single, x => x.String, pattern, options);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RegexIsValid(x => x.String, pattern, options);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("", @"^[a-z]+$")]
        [InlineData("AbCdFg", @"^[a-z]+$")]

        public void Regex_not_is_valid(string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            SingleValues single = new()
            {
                String = input
            };

            _notification.Clear();
            _notification.RegexIsValid(single.String, pattern, options);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RegexIsValid(single, x => x.String, pattern, options);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RegexIsValid(x => x.String, pattern, options);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_if_pattern_empty_exception()
        {
            ArrayValues array = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RegexIsValid(array.String, string.Empty));
            Assert.Throws<ArgumentException>(() => _notification.RegexIsValid(array, x => x.String, string.Empty));
            Assert.Throws<ArgumentException>(() => array.RegexIsValid(x => x.String, string.Empty));
        }


        [Fact]
        public void Check_if_pattern_null_exception()
        {
            ArrayValues array = new()
            {
                String = null
            };

            Assert.Throws<ArgumentNullException>(() => _notification.RegexIsValid(array.String, null));
            Assert.Throws<ArgumentNullException>(() => _notification.RegexIsValid(array, x => x.String, null));
            Assert.Throws<ArgumentNullException>(() => array.RegexIsValid(x => x.String, null));
        }
    }
}
