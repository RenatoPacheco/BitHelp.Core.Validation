using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System.Text.RegularExpressions;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RegexIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        
        [Fact]
        public void Check_text_lowercase_only_valid()
        {
            var single = new SingleValues
            {
                String = "abcdfg"
            };

            notification.Clear();
            notification.RegexIsValid(single.String, @"^[a-z]+$");
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RegexIsValid(single, x => x.String, @"^[a-z]+$");
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_text_ignorecase_using_options_valid()
        {
            var single = new SingleValues
            {
                String = "AbCdFg"
            };

            notification.Clear();
            notification.RegexIsValid(single.String, @"^[a-z]+$", RegexOptions.IgnoreCase);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RegexIsValid(single, x => x.String, @"^[a-z]+$", RegexOptions.IgnoreCase);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_text_only_invalid()
        {
            var single = new SingleValues
            {
                String = "AbCdFg123"
            };

            notification.Clear();
            notification.RegexIsValid(single.String, @"^[a-z]+$");
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RegexIsValid(single, x => x.String, @"^[a-z]+$");
            Assert.False(notification.IsValid());
        }

        [Fact]
        public void Check_if_pattern_empty_exception()
        {
            var array = new ArrayValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => notification.RegexIsValid(array.String, string.Empty));
            Assert.Throws<ArgumentException>(() => notification.RegexIsValid(array, x => x.String, string.Empty));
        }


        [Fact]
        public void Check_if_pattern_null_exception()
        {
            var array = new ArrayValues
            {
                String = null
            };

            Assert.Throws<ArgumentNullException>(() => notification.RegexIsValid(array.String, null));
            Assert.Throws<ArgumentNullException>(() => notification.RegexIsValid(array, x => x.String, null));
        }
    }
}
