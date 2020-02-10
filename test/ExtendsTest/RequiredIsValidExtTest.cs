using BitHelp.Core.Validation.Test.Resources;
using BitHelp.Core.Validation.Extends;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class RequiredIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Fact]
        public void Check_null_invalid()
        {
            var single = new SingleValues
            {
                String = null
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_empty_valid()
        {
            var single = new SingleValues
            {
                String = string.Empty
            };

            _notification.Clear();
            _notification.RequiredIsValid(single.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(single, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_list_item_null_invalid()
        {
            var array = new ArrayValues
            {
                String = new string[] { string.Empty, null }
            };

            _notification.Clear();
            _notification.RequiredIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());
        }

        [Fact]
        public void Check_list_item_empty_valid()
        {
            var array = new ArrayValues
            {
                String = new string[] { string.Empty, string.Empty }
            };

            _notification.Clear();
            _notification.RequiredIsValid(array.String);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(array, x => x.String);
            Assert.True(_notification.IsValid());
        }

        [Fact]
        public void Check_list_no_item_invalid()
        {
            var array = new ArrayValues
            {
                String = Array.Empty<string>()
            };

            _notification.Clear();
            _notification.RequiredIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());
        }


        [Fact]
        public void Check_list_null_invalid()
        {
            var array = new ArrayValues
            {
                String = null
            };

            _notification.Clear();
            _notification.RequiredIsValid(array.String);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.RequiredIsValid(array, x => x.String);
            Assert.False(_notification.IsValid());
        }
    }
}
