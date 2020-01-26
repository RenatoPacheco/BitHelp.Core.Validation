
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class EqualIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();
        
        [Fact]
        public void Check_value_equal_valid()
        {
            var single = new SingleValues
            {
                Long = 123,
                Int = 123
                
            };

            notification.Clear();
            notification.EqualIsValid(single.Long, single.Int);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EqualIsValid(single, x => x.Long, single.Int);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_all_null_valid()
        {
            var single = new SingleValues
            {
                LongNull = null,
                IntNull = null

            };

            notification.Clear();
            notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_value_null_valid()
        {
            var single = new SingleValues
            {
                LongNull = null,
                IntNull = 123

            };

            notification.Clear();
            notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_ignore_compare_null_valid()
        {
            var single = new SingleValues
            {
                LongNull = 123,
                IntNull = null

            };

            notification.Clear();
            notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.True(notification.IsValid());
        }



        [Fact]
        public void Check_diferent_invalid()
        {
            var single = new SingleValues
            {
                LongNull = 123,
                IntNull = 456

            };

            notification.Clear();
            notification.EqualIsValid(single.LongNull, single.IntNull);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.EqualIsValid(single, x => x.LongNull, single.IntNull);
            Assert.False(notification.IsValid());
        }
    }
}
