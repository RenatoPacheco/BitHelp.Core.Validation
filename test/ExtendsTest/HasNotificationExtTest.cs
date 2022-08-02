using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class HasNotificationExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_has_notification()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasNotification(single, x => x.Bool));

            _notification.Clear();
            Assert.False(_notification.HasNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.True(single.HasNotification(x => x.Bool));

            single.Notifications.Clear();
            Assert.False(single.HasNotification(x => x.Bool));
        }

        [Fact]
        public void Check_is_valid()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.IsValid(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.String, message);
            Assert.True(_notification.IsValid(single, x => x.Bool));

            _notification.Clear();
            _notification.AddSuccess<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.IsValid(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.False(single.IsValid(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.String, message);
            Assert.True(single.IsValid(x => x.Bool));

            single.Notifications.Clear();
            single.AddSuccessNotification(x => x.Bool, message);
            Assert.True(single.IsValid(x => x.Bool));
        }

        [Fact]
        public void Check_has_error()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasErrorNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddUnauthorized<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.HasErrorNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.True(single.HasErrorNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddUnauthorizedNotification(x => x.Bool, message);
            Assert.False(single.HasErrorNotification(x => x.Bool));
        }

        [Fact]
        public void Check_has_unauthorized()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddUnauthorized<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasUnauthorizedNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.HasUnauthorizedNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddUnauthorizedNotification(x => x.Bool, message);
            Assert.True(single.HasUnauthorizedNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.False(single.HasUnauthorizedNotification(x => x.Bool));
        }

        [Fact]
        public void Check_has_success()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddSuccess<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasSuccessNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.HasSuccessNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddSuccessNotification(x => x.Bool, message);
            Assert.True(single.HasSuccessNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.False(single.HasSuccessNotification(x => x.Bool));
        }

        [Fact]
        public void Check_has_info()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddInfo<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasInfoNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.HasInfoNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddInfoNotification(x => x.Bool, message);
            Assert.True(single.HasInfoNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.False(single.HasInfoNotification(x => x.Bool));
        }

        [Fact]
        public void Check_has_alert()
        {
            SingleValues single = new SingleValues();
            string message = "Message text";

            _notification.Clear();
            _notification.AddAlert<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasAlertNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message);
            Assert.False(_notification.HasAlertNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddAlertNotification(x => x.Bool, message);
            Assert.True(single.HasAlertNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message);
            Assert.False(single.HasAlertNotification(x => x.Bool));
        }

        [Fact]
        public void Check_has_fatal()
        {
            SingleValues single = new SingleValues();
            Exception message = new Exception();

            _notification.Clear();
            _notification.AddFatal<SingleValues>(x => x.Bool, message);
            Assert.True(_notification.HasFatalNotification(single, x => x.Bool));

            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.Bool, message.StackTrace);
            Assert.False(_notification.HasFatalNotification(single, x => x.Bool));

            single.Notifications.Clear();
            single.AddFatalNotification(x => x.Bool, message);
            Assert.True(single.HasFatalNotification(x => x.Bool));

            single.Notifications.Clear();
            single.AddErrorNotification(x => x.Bool, message.StackTrace);
            Assert.False(single.HasFatalNotification(x => x.Bool));
        }
    }
}
