using Xunit;
using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Extend;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SetMessageExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_set_message_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string message = "New message";

            _notification.Clear();
            _notification.LongIsValid(single.String)
                .SetMessage(message);

            Assert.False(_notification.IsValid());
            Assert.Equal(message, _notification.Messages[0].Message);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetMessage(message);

            Assert.False(_notification.IsValid());
            Assert.Equal(message, _notification.Messages[0].Message);
        }

        [Fact]
        public void Check_set_message_expression_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string message = "{0} new message";
            string finalMessage = string.Format(message, single.GetDisplayName(x => x.String));

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                    .SetMessage(finalMessage);

            Assert.False(_notification.IsValid());
            Assert.Equal(finalMessage, _notification.Messages[0].Message);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                    .SetMessage(message);

            Assert.False(_notification.IsValid());
            Assert.Equal(finalMessage, _notification.Messages[0].Message);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                    .SetMessage<SingleValues>(x => x.String, message);

            Assert.False(_notification.IsValid());
            Assert.Equal(finalMessage, _notification.Messages[0].Message);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetMessage(single, x => x.String, message);

            Assert.False(_notification.IsValid());
            Assert.Equal(finalMessage, _notification.Messages[0].Message);
        }

        [Fact]
        public void Check_set_message_null_invalid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string message = null;

            _notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage<SingleValues>(x => x.String, message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(single, x => x.String, message));
        }

        [Fact]
        public void Check_set_message_empty_invalid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string message = string.Empty;

            _notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage<SingleValues>(x => x.String, message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(single, x => x.String, message));
        }

        [Fact]
        public void Check_set_message_empty_whith_space_invalid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string message = "     ";

            _notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage<SingleValues>(x => x.String, message));

            Assert.Throws<ArgumentNullException>(() =>
                _notification.LongIsValid(single, x => x.String)
                    .SetMessage(single, x => x.String, message));
        }
    }
}
