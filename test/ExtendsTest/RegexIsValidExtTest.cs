using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System.Text.RegularExpressions;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RegexIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        
        [Fact]
        public void Check_text_lowercase_only_valid()
        {
            var single = new SingleValues
            {
                String = "abcdfg"
            };

            _notification.Clear();
            _notification.RegexIsValid(single.String, @"^[a-z]+$");
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RegexIsValid(single, x => x.String, @"^[a-z]+$");
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_text_ignorecase_using_options_valid()
        {
            var single = new SingleValues
            {
                String = "AbCdFg"
            };

            _notification.Clear();
            _notification.RegexIsValid(single.String, @"^[a-z]+$", RegexOptions.IgnoreCase);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RegexIsValid(single, x => x.String, @"^[a-z]+$", RegexOptions.IgnoreCase);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_text_only_invalid()
        {
            var single = new SingleValues
            {
                String = "AbCdFg123"
            };

            _notification.Clear();
            _notification.RegexIsValid(single.String, @"^[a-z]+$");
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RegexIsValid(single, x => x.String, @"^[a-z]+$");
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_pattern_empty_exception()
        {
            var array = new ArrayValues
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.RegexIsValid(array.String, string.Empty));
            Assert.Throws<ArgumentException>(() => _notification.RegexIsValid(array, x => x.String, string.Empty));
        }


        [Fact]
        public void Check_if_pattern_null_exception()
        {
            var array = new ArrayValues
            {
                String = null
            };

            Assert.Throws<ArgumentNullException>(() => _notification.RegexIsValid(array.String, null));
            Assert.Throws<ArgumentNullException>(() => _notification.RegexIsValid(array, x => x.String, null));
        }
    }
}
