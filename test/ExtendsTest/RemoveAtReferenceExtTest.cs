using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RemoveAtReferenceExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_if_the_reference_has_been_removed_by_the_validationNotification()
        {
            SingleValues single = new()
            {
                Int = 100,
                IntNull = 100
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.Int, 10);
            _notification.MaxNumberIsValid(single, x => x.IntNull, 10);

            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.IntNull));

            _notification.RemoveAtReference<SingleValues>(x => x.Int);
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.IntNull));

            _notification.RemoveAtReference<SingleValues>(x => x.IntNull);
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.IntNull));
        }

        [Fact]
        public void Check_if_the_reference_has_been_removed_by_the_expression_in_this_object()
        {
            SingleValues single = new()
            {
                Int = 100,
                IntNull = 100
            };

            _notification.Clear();
            _notification.MaxNumberIsValid(single, x => x.Int, 10);
            _notification.MaxNumberIsValid(single, x => x.IntNull, 10);

            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.IntNull));

            _notification.RemoveAtReference(single, x => x.Int);
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(_notification.Messages, x => x.Reference == nameof(single.IntNull));

            _notification.RemoveAtReference(single, x => x.IntNull);
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.Int));
            Assert.DoesNotContain(_notification.Messages, x => x.Reference == nameof(single.IntNull));
        }

        [Fact]
        public void Check_if_the_reference_has_been_removed_by_the_iSelfValidation()
        {
            SingleValues single = new()
            {
                Int = 100,
                IntNull = 100
            };

            single.Notifications.Clear();
            single.MaxNumberIsValid(x => x.Int, 10);
            single.MaxNumberIsValid(x => x.IntNull, 10);

            Assert.Contains(single.Notifications.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(single.Notifications.Messages, x => x.Reference == nameof(single.IntNull));

            single.RemoveAtReference(x => x.Int);
            Assert.DoesNotContain(single.Notifications.Messages, x => x.Reference == nameof(single.Int));
            Assert.Contains(single.Notifications.Messages, x => x.Reference == nameof(single.IntNull));

            single.RemoveAtReference(x => x.IntNull);
            Assert.DoesNotContain(single.Notifications.Messages, x => x.Reference == nameof(single.Int));
            Assert.DoesNotContain(single.Notifications.Messages, x => x.Reference == nameof(single.IntNull));
        }
    }
}
