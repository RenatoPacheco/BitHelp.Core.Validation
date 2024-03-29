﻿using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class ExactCharactersIsValidExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_characters_valid()
        {
            SingleValues single = new()
            {
                String = "ExactCharactersIsValid"
            };

            _notification.Clear();
            _notification.ExactCharactersIsValid(single.String, single.String.Length);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.ExactCharactersIsValid(single, x => x.String, single.String.Length);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(x => x.String, single.String.Length);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(single.String, single.String.Length);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_max_characters_invalid()
        {
            SingleValues single = new()
            {
                String = "ExactCharactersIsValid"
            };

            _notification.Clear();
            _notification.ExactCharactersIsValid(single.String, single.String.Length - 1);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.ExactCharactersIsValid(single, x => x.String, single.String.Length - 1);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(x => x.String, single.String.Length - 1);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(single.String, single.String.Length - 1);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_min_characters_invalid()
        {
            SingleValues single = new()
            {
                String = "ExactCharactersIsValid"
            };

            _notification.Clear();
            _notification.ExactCharactersIsValid(single.String, single.String.Length + 1);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.ExactCharactersIsValid(single, x => x.String, single.String.Length + 1);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(x => x.String, single.String.Length + 1);
            Assert.False(single.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(single.String, single.String.Length + 1);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_null_valid()
        {
            SingleValues single = new()
            {
                String = null
            };

            _notification.Clear();
            _notification.ExactCharactersIsValid(single.String, 101);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.ExactCharactersIsValid(single, x => x.String, 101);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(x => x.String, 101);
            Assert.True(single.IsValid());

            single.Notifications.Clear();
            single.ExactCharactersIsValid(single.String, 101);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_option_0_exception()
        {
            SingleValues single = new()
            {
                String = null
            };

            Assert.Throws<ArgumentException>(() => _notification.ExactCharactersIsValid(single.String, 0));
            Assert.Throws<ArgumentException>(() => _notification.ExactCharactersIsValid(single, x => x.String, 0));
            Assert.Throws<ArgumentException>(() => single.ExactCharactersIsValid(x => x.String, 0));
            Assert.Throws<ArgumentException>(() => single.ExactCharactersIsValid(single.String, 0));
        }
    }
}
