﻿using Xunit;
using BitHelp.Core.Validation.Extends;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Test.ValidationNotificationTest
{
    public class AddWithISelfValidationTest : ISelfValidation
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                Notifications.RemoveAtReference(nameof(Text));
                Notifications.NotEmptyIsValid(this, x => x.Text);
                Notifications.MinCharactersIsValid(this, x => x.Text, 10);
            }
        }

        private string _email;
        [Display(Name = "E-mail")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                Notifications.RemoveAtReference(nameof(Email));
                Notifications.NotEmptyIsValid(this, x => x.Email);
                Notifications.EmailIsValid(this, x => x.Email);
            }
        }

        public ValidationNotification Notifications { get; } = new();

        public bool IsValid()
        {
            Notifications.RequiredIsValid(this, x => x.Text);
            Notifications.RequiredIsValid(this, x => x.Email);
            return Notifications.IsValid();
        }

        [Fact]
        public void Check_if_add_notifications()
        {
            ValidationNotification notifications = new();

            Text = null;
            Email = null;

            Assert.False(IsValid());
            Assert.True(notifications.IsValid());

            notifications.Add(this);

            Assert.False(IsValid());
            Assert.False(notifications.IsValid());
            Assert.Equal(2, notifications.Messages.Count);
            Assert.Collection(notifications.Messages, item => Assert.Equal(nameof(Text), item.Reference),
                                                      item => Assert.Equal(nameof(Email), item.Reference));
        }

        [Fact]
        public void Check_if_add_only_one_notifications()
        {
            ValidationNotification notifications = new();

            Text = "text here";
            Email = "email@test.site.com";

            Assert.False(IsValid());
            Assert.True(notifications.IsValid());

            notifications.Add(this);

            Assert.False(IsValid());
            Assert.False(notifications.IsValid());
            Assert.Single(notifications.Messages);
            Assert.Collection(notifications.Messages, item => Assert.Equal(nameof(Text), item.Reference));
        }

        [Fact]
        public void Check_if_add_notifications_seting_prefix()
        {
            ValidationNotification notifications = new();
            string prefix = "Test";

            Text = null;
            Email = null;

            Assert.False(IsValid());
            Assert.True(notifications.IsValid());

            notifications.Add("Text error....");
            Notifications.Add("Other error...");
            notifications.Add(this, prefix);

            Assert.False(IsValid());
            Assert.False(notifications.IsValid());
            Assert.Equal(4, notifications.Messages.Count);
            Assert.Collection(notifications.Messages, item => Assert.Null(item.Reference),
                                                      item => Assert.Equal($"{prefix}.{nameof(Text)}", item.Reference),
                                                      item => Assert.Equal($"{prefix}.{nameof(Email)}", item.Reference),
                                                      item => Assert.Equal($"{prefix}", item.Reference));
        }

    }
}
