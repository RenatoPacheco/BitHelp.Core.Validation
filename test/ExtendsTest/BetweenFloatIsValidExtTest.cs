using Xunit;
using System;
using System.Collections.Generic;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenFloatIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();
        private readonly float[] _options = new float[] { 1, 2, 3 };

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_value_1_valid(bool deny)
        {
            SingleValues single = new()
            {
                String = "1",
                Float = 1
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            #endregion

            #region float

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Float, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Float, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.Float, _options, deny);
            Assert.Equal(!deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.Float, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.Float, _options, deny);
            Assert.Equal(!deny, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_10_invalid(bool deny)
        {
            SingleValues single = new()
            {
                String = "10",
                Float = 10
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, deny);
            Assert.Equal(deny, single.IsValid());

            #endregion

            #region float

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.Float, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.Float, _options, deny);
            Assert.Equal(deny, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.Float, _options, deny);
            Assert.Equal(deny, single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.Float, _options, deny);
            Assert.Equal(deny, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_invalid_value_even_converted(bool deny)
        {
            SingleValues single = new()
            {
                String = "text"
            };

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, deny);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_ignore_null_valid(bool deny)
        {
            SingleValues single = new()
            {
                String = null,
                FloatNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.String, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.String, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.String, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.String, _options, deny);
            Assert.True(single.IsValid());

            #endregion

            #region float

            _notification.Clear();
            _notification.BetweenNumberIsValid(single.FloatNull, _options, deny);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenNumberIsValid(single, x => x.FloatNull, _options, deny);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(x => x.FloatNull, _options, deny);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenNumberIsValid(single.FloatNull, _options, deny);
            Assert.True(single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_null_exception(bool deny)
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<float> options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options, deny));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_option_empty_exception(bool deny)
        {
            SingleValues single = new()
            {
                String = null
            };

            IList<float> options = Array.Empty<float>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single.String, options, deny));
            Assert.Throws<ArgumentException>(() => _notification.BetweenNumberIsValid(single, x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(x => x.String, options, deny));
            Assert.Throws<ArgumentException>(() => single.BetweenNumberIsValid(single.String, options, deny));
        }
    }
}
