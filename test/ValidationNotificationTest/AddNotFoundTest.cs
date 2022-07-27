using Xunit;
using System;
using System.Linq;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ValidationNotificationTest
{
    public class AddNotFoundTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

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
            _notification.AddNotFound<SingleValues>(x => x.BoolNull);

            var reference = GetReference<SingleValues>(x => x.BoolNull);
            var result = _notification.Messages.First();

            Assert.Equal(reference, result.Reference);
            Assert.Null(result.Exception);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_expression_set_message()
        {
            _notification.Clear();
            _notification.AddNotFound<SingleValues>(x => x.BoolNull, message: "Message here");

            var result = _notification.Messages.First();

            Assert.Equal("Message here", result.Message);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_expression_set_message_with_display_name()
        {
            _notification.Clear();
            _notification.AddNotFound<SingleValues>(x => x.BoolNull, message: "{0} message here");

            var display = GetDisplay<SingleValues>(x => x.BoolNull);
            var message = string.Format("{0} message here", display);
            var result = _notification.Messages.First();

            Assert.Equal(message, result.Message);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_expression_set_reference()
        {
            _notification.Clear();
            _notification.AddNotFound<SingleValues>(x => x.BoolNull, reference: "reference");

            var result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_expression_set_exception()
        {
            _notification.Clear();
            _notification.AddNotFound<SingleValues>(x => x.BoolNull, exception: new Exception("NotFound here"));

            var result = _notification.Messages.First();

            Assert.Equal("NotFound here", result.Exception.Message);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_default()
        {
            _notification.Clear();
            _notification.AddNotFound("Message here");

            var result = _notification.Messages.First();

            Assert.Null(result.Reference);
            Assert.Equal("Message here", result.Message);
            Assert.Null(result.Exception);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }

        [Fact]
        public void Check_setting_all_values()
        {
            _notification.Clear();
            _notification.AddNotFound("Message here", reference: "reference", exception: new Exception("NotFound here"));

            var result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal("Message here", result.Message);
            Assert.Equal("NotFound here", result.Exception.Message);
            Assert.Equal(ValidationType.NotFound, result.Type);
        }
    }
}
