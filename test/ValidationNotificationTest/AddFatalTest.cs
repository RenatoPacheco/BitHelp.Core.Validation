using Xunit;
using System;
using System.Linq;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ValidationNotificationTest
{
    public class AddFatalTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        private string GetReference<T>(Expression<Func<T, object>> expression)
        {
            return expression.PropertyTrail();
        }
        
        private string GetDisplay<T>(Expression<Func<T, object>> expression)
        {
            return expression.PropertyDisplay();
        }

        [Fact]
        public void Check_expression_default()
        {
            _notification.Clear();
            _notification.AddFatal<SingleValues>(x => x.BoolNull, new Exception("Error here"));

            var reference = GetReference<SingleValues>(x => x.BoolNull);
            var result = _notification.Messages.First();

            Assert.Equal(reference, result.Reference);
            Assert.Equal("Error here", result.Message);
            Assert.Equal("Error here", result.Exception.Message);
            Assert.Equal(ValidationType.Fatal, result.Type);
        }

        [Fact]
        public void Check_expression_set_reference()
        {
            _notification.Clear();
            _notification.AddFatal<SingleValues>(x => x.BoolNull, new Exception("Error here"), reference: "reference");

            var result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal(ValidationType.Fatal, result.Type);
        }
        [Fact]
        public void Check_default()
        {
            _notification.Clear();
            _notification.AddFatal(new Exception("Error here"));

            var result = _notification.Messages.First();

            Assert.Null(result.Reference);
            Assert.Equal("Error here", result.Message);
            Assert.Equal("Error here", result.Exception.Message);
            Assert.Equal(ValidationType.Fatal, result.Type);
        }

        [Fact]
        public void Check_setting_all_values()
        {
            _notification.Clear();
            _notification.AddFatal(new Exception("Error here"), reference: "reference");

            var result = _notification.Messages.First();

            Assert.Equal("reference", result.Reference);
            Assert.Equal("Error here", result.Message);
            Assert.Equal(ValidationType.Fatal, result.Type);
        }
    }
}
