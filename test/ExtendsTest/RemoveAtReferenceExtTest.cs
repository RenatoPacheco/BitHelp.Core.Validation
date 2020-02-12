using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RemoveAtReferenceExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_date_pt_BR_valid()
        {
            var single = new SingleValues
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
    }
}
