using System;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class ComparePlusDateTimeIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        readonly DateTime _value = DateTime.Now;

        [Fact]
        public void Check_all_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                DateTimeNull = null
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            var single = new SingleValues
            {
                String = _value.AddMinutes(123).ToString(),
                DateTimeNull = null
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_null_valid()
        {
            var single = new SingleValues
            {
                String = null,
                DateTimeNull = _value.AddMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_value_less_invalid()
        {
            var single = new SingleValues
            {
                String = _value.AddMinutes(123).ToString(),
                DateTimeNull = _value.AddMinutes(456)
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            var single = new SingleValues
            {
                String = _value.AddMinutes(123).ToString(),
                DateTimeNull = _value.AddMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_value_plus_valid()
        {
            var single = new SingleValues
            {
                String = _value.AddMinutes(456).ToString(),
                DateTimeNull = _value.AddMinutes(123)
            };

            _notification.Clear();
            _notification.ComparePlusDateTimeIsValid(single, x => x.String, x => x.DateTimeNull);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ComparePlusDateTimeIsValid(x => x.String, x => x.DateTimeNull);
            Assert.True(single.IsValid());
        }
    }
}