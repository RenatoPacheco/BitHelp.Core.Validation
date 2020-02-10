using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class CompareLessNumberIsValidTest
    {
        [CompareLessNumberIsValid(nameof(Compare))]
        public int? Value { get; set; }

        public int? Compare { get; set; }

        [Fact]
        public void Check_all_null_valid()
        {
            var model = new CompareLessNumberIsValidTest();
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            var model = new CompareLessNumberIsValidTest()
            {
                Value = 123,
                Compare = null
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_null_valid()
        {
            var model = new CompareLessNumberIsValidTest()
            {
                Value = null,
                Compare = 123
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_less_valid()
        {
            var model = new CompareLessNumberIsValidTest()
            {
                Value = 123,
                Compare = 456
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            var model = new CompareLessNumberIsValidTest()
            {
                Value = 123,
                Compare = 123
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_plus_invalid()
        {
            var model = new CompareLessNumberIsValidTest()
            {
                Value = 456,
                Compare = 123
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }
    }
}
