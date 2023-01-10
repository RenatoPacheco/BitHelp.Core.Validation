﻿using Xunit;
using System;
using System.Collections.Generic;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenSbyteIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly sbyte[] _options = new sbyte[] { 1, 2, 3 };

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = "1",
                Sbyte = 1
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion

            #region sbyte

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Sbyte, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Sbyte, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.Sbyte, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.Sbyte, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.Sbyte, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_10_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = "10",
                Sbyte = 10
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            #endregion

            #region sbyte

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Sbyte, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.Sbyte, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.Sbyte, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.Sbyte, _options, denay);
            Assert.Equal(denay, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_text_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, denay);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, denay);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, denay);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, denay);
            Assert.False(single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_null_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = null,
                SbyteNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, denay);
            Assert.True(single.IsValid());

            #endregion

            #region sbyte

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.SbyteNull, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.SbyteNull, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.SbyteNull, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.SbyteNull, _options, denay);
            Assert.True(single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_null_exception(bool denay)
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<sbyte> options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options, denay));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_empty_exception(bool denay)
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<sbyte> options = Array.Empty<sbyte>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options, denay));
        }
    }
}
