using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_value_equal_valid()
        {
            SingleValues single = new()
            {
                Long = 123,
                Int = 123

            };

            _notification.Clear();
            _notification.EqualIsValid(single.Long, single.Int);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.Long, single.Int);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.Long, single.Int);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_all_null_valid()
        {
            SingleValues single = new()
            {
                LongNull = null,
                IntNull = null

            };

            _notification.Clear();
            _notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.LongNull, single.IntNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_value_null_valid()
        {
            SingleValues single = new()
            {
                LongNull = null,
                IntNull = 123

            };

            _notification.Clear();
            _notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.LongNull, single.IntNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_ignore_compare_null_valid()
        {
            SingleValues single = new()
            {
                LongNull = 123,
                IntNull = null

            };

            _notification.Clear();
            _notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.LongNull, single.IntNull);
            Assert.True(single.IsValid());
        }



        [Fact]
        public void Check_diferent_invalid()
        {
            SingleValues single = new()
            {
                LongNull = 123,
                IntNull = 456

            };

            _notification.Clear();
            _notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.LongNull, single.IntNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_string_and_int_with_equal_value_valid()
        {
            SingleValues single = new()
            {
                String = "123",
                Int = 123
            };

            _notification.Clear();
            _notification.EqualIsValid(single.String, single.Int);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.EqualIsValid(single, x => x.String, single.Int);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.EqualIsValid(x => x.String, single.Int);
            Assert.True(single.IsValid());
        }
    }
}
