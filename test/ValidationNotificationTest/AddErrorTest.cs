﻿using Xunit;
using System;
using System.Linq;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ValidationNotificationTest
{
    public class AddErrorTest
    {
        private readonly ValidationNotification _notification = new();

        private string GetReference<T>(Expression<Func<T, object>> expression)
        {
            return expression.PropertyPath();
        }

        private string GetDisplay<T>(Expression<Func<T, object>> expression)
        {
            return expression.PropertyDisplay();
        }

        [Fact]
        public void Check_expression_default()
        {
            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.BoolNull);

            string reference = GetReference<SingleValues>(x => x.BoolNull);
            ValidationMessage result = _notification.Messages.First();

            Assert.Equal(reference, result.Reference);
            Assert.Null(result.Exception);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_expression_set_message()
        {
            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.BoolNull, message: "Message here");

            ValidationMessage result = _notification.Messages.First();

            Assert.Equal("Message here", result.Message);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_expression_set_message_with_display_name()
        {
            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.BoolNull, message: "{0} message here");

            string display = GetDisplay<SingleValues>(x => x.BoolNull);
            string message = string.Format("{0} message here", display);
            ValidationMessage result = _notification.Messages.First();

            Assert.Equal(message, result.Message);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_expression_set_reference()
        {
            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.BoolNull, reference: "reference");

            ValidationMessage result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_expression_set_exception()
        {
            _notification.Clear();
            _notification.AddError<SingleValues>(x => x.BoolNull, exception: new("Error here"));

            ValidationMessage result = _notification.Messages.First();

            Assert.Equal("Error here", result.Exception.Message);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_default()
        {
            _notification.Clear();
            _notification.AddError("Message here");

            ValidationMessage result = _notification.Messages.First();

            Assert.Null(result.Reference);
            Assert.Equal("Message here", result.Message);
            Assert.Null(result.Exception);
            Assert.Equal(ValidationType.Error, result.Type);
        }

        [Fact]
        public void Check_setting_all_values()
        {
            _notification.Clear();
            _notification.AddError("Message here", reference: "reference", exception: new("Error here"));

            ValidationMessage result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal("Message here", result.Message);
            Assert.Equal("Error here", result.Exception.Message);
            Assert.Equal(ValidationType.Error, result.Type);
        }
    }
}
