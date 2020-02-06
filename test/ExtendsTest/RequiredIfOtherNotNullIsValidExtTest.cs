using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;


namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIfOtherNotNullIsValidExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_all_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                BoolNull = null                
            };

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_compara_null_valid()
        {
            var single = new SingleValues
            {
                String = string.Empty,
                BoolNull = null
            };

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(notification.IsValid());
        }

        [Fact]
        public void Check_all_not_null_valid()
        {
            var single = new SingleValues
            {
                String = string.Empty,
                BoolNull = true
            };

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.True(notification.IsValid());

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.True(notification.IsValid());
        }


        [Fact]
        public void Check_value_null_invalid()
        {
            var single = new SingleValues
            {
                String = null,
                BoolNull = true
            };

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single.String, single.BoolNull);
            Assert.False(notification.IsValid());

            notification.Clear();
            notification.RequiredIfOtherNotNullIsValid(single, x => x.String, single.BoolNull);
            Assert.False(notification.IsValid());
        }
    }
}
