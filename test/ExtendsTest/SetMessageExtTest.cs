using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;
using BitHelp.Core.Validation.Test.Extend;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SetMessageExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_set_message_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string message = "New message";

            notification.Clear();
            notification.LongIsValid(single.String).SetMessage(message);

            Assert.False(notification.IsValid());
            Assert.Equal(message, notification.Messages[0].Message);

            notification.Clear();
            notification.LongIsValid(single, x => x.String).SetMessage(message);

            Assert.False(notification.IsValid());
            Assert.Equal(message, notification.Messages[0].Message);
        }

        [Fact]
        public void Check_set_message_expression_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string message = "{0} new message";
            string messageFinal = string.Format(message, single.GetDisplayName(x => x.String));

            notification.Clear();
            notification.LongIsValid(single, x => x.String)
                    .SetMessage<SingleValues>(x => x.String, message);

            Assert.False(notification.IsValid());
            Assert.Equal(messageFinal, notification.Messages[0].Message);

            notification.Clear();
            notification.LongIsValid(single, x => x.String)
                .SetMessage(single, x => x.String, message);

            Assert.False(notification.IsValid());
            Assert.Equal(messageFinal, notification.Messages[0].Message);
        }

        [Fact]
        public void Check_set_message_null_invalid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string message = null;

            notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single.String).SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single, x => x.String).SetMessage(message));
        }

        [Fact]
        public void Check_set_message_empty_invalid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string message = string.Empty;

            notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single.String).SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single, x => x.String).SetMessage(message));
        }

        [Fact]
        public void Check_set_message_empty_whith_space_invalid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string message = "     ";

            notification.Clear();
            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single.String).SetMessage(message));

            Assert.Throws<ArgumentNullException>(() =>
                notification.LongIsValid(single, x => x.String).SetMessage(message));
        }
    }
}
