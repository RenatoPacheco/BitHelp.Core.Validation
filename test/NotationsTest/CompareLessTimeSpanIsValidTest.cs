using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class CompareLessTimeSpanIsValidTest
    {
        [CompareLessTimeSpanIsValid(nameof(Compare))]
        public TimeSpan? Value { get; set; }

        public TimeSpan? Compare { get; set; }

        [Fact]
        public void Check_all_null_valid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest();
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = null
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_null_valid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest()
            {
                Value = null,
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_less_valid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_plus_invalid()
        {
            CompareLessTimeSpanIsValidTest model = new CompareLessTimeSpanIsValidTest()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }
    }
}
