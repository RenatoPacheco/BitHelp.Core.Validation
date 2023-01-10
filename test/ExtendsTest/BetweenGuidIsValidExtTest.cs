using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using System.Linq;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class BetweenGuidIsValidExtTest
    {
        public BetweenGuidIsValidExtTest()
        {
            _options = new Guid[]
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };
        }

        private readonly ValidationNotification _notification = new();
        private readonly Guid[] _options;

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_contain_first_value_valid(bool denay)
        {
            SingleValues single = new()
            {
                String = _options.First().ToString(),
                Guid = _options.First()
            };

            #region string

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.String, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.String, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion

            #region guid

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.Guid, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.Guid, _options, denay);
            Assert.Equal(!denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.Guid, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.Guid, _options, denay);
            Assert.Equal(!denay, single.IsValid());

            #endregion
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Check_not_contain_value_invalid(bool denay)
        {
            SingleValues single = new()
            {
                String = Guid.NewGuid().ToString(),
                Guid = Guid.NewGuid()
            };

            #region string

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.String, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.String, _options, denay);
            Assert.Equal(denay, single.IsValid());

            #endregion

            #region guid

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.Guid, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.Guid, _options, denay);
            Assert.Equal(denay, _notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.Guid, _options, denay);
            Assert.Equal(denay, single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.Guid, _options, denay);
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
            _notification.BetweenGuidIsValid(single.String, _options, denay);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.String, _options, denay);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.String, _options, denay);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.String, _options, denay);
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
                GuidNull = null
            };

            #region string

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.String, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.String, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.String, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.String, _options, denay);
            Assert.True(single.IsValid());

            #endregion

            #region guid

            _notification.Clear();
            _notification.BetweenGuidIsValid(single.GuidNull, _options, denay);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.BetweenGuidIsValid(single, x => x.GuidNull, _options, denay);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(x => x.GuidNull, _options, denay);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.BetweenGuidIsValid(single.GuidNull, _options, denay);
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

            Guid[] options = null;

            Assert.Throws<ArgumentException>(() => _notification.BetweenGuidIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenGuidIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenGuidIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenGuidIsValid(single.String, options, denay));
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

            Guid[] options = Array.Empty<Guid>();

            Assert.Throws<ArgumentException>(() => _notification.BetweenGuidIsValid(single.String, options, denay));
            Assert.Throws<ArgumentException>(() => _notification.BetweenGuidIsValid(single, x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenGuidIsValid(x => x.String, options, denay));
            Assert.Throws<ArgumentException>(() => single.BetweenGuidIsValid(single.String, options, denay));
        }
    }
}
