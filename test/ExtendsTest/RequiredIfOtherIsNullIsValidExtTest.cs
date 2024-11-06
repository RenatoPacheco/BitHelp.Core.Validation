using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;


namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIfOtherIsNullIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_all_null_invalid()
        {
            SingleValues single = new()
            {
                String = null,
                BoolNull = null
            };

            _notification.Clear();
            _notification.RequiredIfOtherIsNullIsValid(single, x => x.String, y => y.BoolNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherIsNullIsValid(x => x.String, y => y.BoolNull);
            Assert.False(single.IsValid());

        }

        [Fact]
        public void Check_compara_null_valid()
        {
            SingleValues single = new()
            {
                String = string.Empty,
                BoolNull = null
            };

            _notification.Clear();
            _notification.RequiredIfOtherIsNullIsValid(single, x => x.String, y => y.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherIsNullIsValid(x => x.String, y => y.BoolNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_all_not_null_valid()
        {
            SingleValues single = new()
            {
                String = string.Empty,
                BoolNull = true
            };

            _notification.Clear();
            _notification.RequiredIfOtherIsNullIsValid(single, x => x.String, y => y.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherIsNullIsValid(x => x.String, y => y.BoolNull);
            Assert.True(single.IsValid());
        }


        [Fact]
        public void Check_value_null_valid()
        {
            SingleValues single = new()
            {
                String = null,
                BoolNull = true
            };

            _notification.Clear();
            _notification.RequiredIfOtherIsNullIsValid(single, x => x.String, y => y.BoolNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.RequiredIfOtherIsNullIsValid(x => x.String, y => y.BoolNull);
            Assert.True(single.IsValid());
        }
    }
}
