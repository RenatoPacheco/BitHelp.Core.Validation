using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class MaxDateTimeIsValidExtText
    {
        readonly ValidationNotification _notification = new ValidationNotification();
        readonly DateTime date = DateTime.Now;

        [Fact]
        public void Check_if_5_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(5).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_10_is_in_maximum_10_valid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(10).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_if_11_is_in_maximum_10_invalid()
        {

            var single = new SingleValues
            {
                String = date.AddDays(11).ToString()
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_text_invalid()
        {
            var single = new SingleValues
            {
                String = "text"
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_empty_invalid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_if_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single.String, date.AddDays(10));
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.MaxDateTimeIsValid(single, x => x.String, date.AddDays(10));
            Assert.True(_notification.IsValid());
        }
    }
}
