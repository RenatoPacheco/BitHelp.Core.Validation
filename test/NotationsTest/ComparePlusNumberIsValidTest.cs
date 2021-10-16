using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class ComparePlusNumberIsValidTest
    {
        [ComparePlusNumberIsValid(nameof(Compare))]
        public object Value { get; set; }

        public object Compare { get; set; }

        [Theory]
        [InlineData(456, null)]
        [InlineData(null, 456)]
        [InlineData(null, null)]
        [InlineData(456, 123)]
        [InlineData("456", "123")]
        [InlineData("abc", 456)]
        [InlineData(456, "abcd")]
        [InlineData("abc", "abcd")]
        public void Check_value_is_valid(object value, object compare)
        {
            var model = new ComparePlusNumberIsValidTest()
            {
                Value = value,
                Compare = compare
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, context, results, true);
            Assert.True(result);
        }

        [Theory]
        [InlineData(456, 456)]
        [InlineData(123, 456)]
        [InlineData("456", "456")]
        [InlineData("123", "456")]
        public void Check_value_not_is_valid(object value, object compare)
        {
            var model = new ComparePlusNumberIsValidTest()
            {
                Value = value,
                Compare = compare
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, context, results, true);
            Assert.False(result);
        }
    }
}
