using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class CompareLessNumberIsValidTest
    {
        [CompareLessNumberIsValid(nameof(Compare))]
        public object Value { get; set; }

        public object Compare { get; set; }

        [Theory]
        [InlineData(123, null)]
        [InlineData(null, 123)]
        [InlineData(null, null)]
        [InlineData(123, 456)]
        [InlineData("123", "456")]
        [InlineData("abc", 123)]
        [InlineData(123, "abcd")]
        [InlineData("abc", "abcd")]
        public void Check_value_is_valid(object value, object compare)
        {
            CompareLessNumberIsValidTest model = new CompareLessNumberIsValidTest()
            {
                Value = value,
                Compare = compare
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(model, context, results, true);
            Assert.True(result);
        }

        [Theory]
        [InlineData(123, 123)]
        [InlineData(456, 123)]
        [InlineData("123", "123")]
        [InlineData("456", "123")]
        public void Check_value_not_is_valid(object value, object compare)
        {
            CompareLessNumberIsValidTest model = new CompareLessNumberIsValidTest()
            {
                Value = value,
                Compare = compare
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(model, context, results, true);
            Assert.False(result);
        }
    }
}
