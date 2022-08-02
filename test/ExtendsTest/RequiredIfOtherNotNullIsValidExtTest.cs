using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;


namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIfOtherNotNullIsValidExtTest
    {
        private readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_all_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = null,
                BoolNull = null
            };

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherNotNullIsValid(x => x.String, single.BoolNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_compara_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty,
                BoolNull = null
            };

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherNotNullIsValid(x => x.String, single.BoolNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_all_not_null_valid()
        {
            SingleValues single = new SingleValues
            {
                String = string.Empty,
                BoolNull = true
            };

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherNotNullIsValid(x => x.String, single.BoolNull);
            Assert.True(single.IsValid());
        }


        [Fact]
        public void Check_value_null_invalid()
        {
            SingleValues single = new SingleValues
            {
                String = null,
                BoolNull = true
            };

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherNotNullIsValid(x => x.String, single.BoolNull);
            Assert.False(single.IsValid());
        }
    }
}
