﻿using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class RequiredIfOtherNotNullIsValidTest
    {
        [RequiredIfOtherNotNullIsValid(nameof(Compare))]
        public string Value { get; set; }

        public string Compare { get; set; }

        [Fact]
        public void Check_all_null_valid()
        {
            RequiredIfOtherNotNullIsValidTest model = new();
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_all_not_null_valid()
        {
            RequiredIfOtherNotNullIsValidTest model = new()
            {
                Value = string.Empty,
                Compare = string.Empty
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_not_null_invalid()
        {
            RequiredIfOtherNotNullIsValidTest model = new()
            {
                Compare = string.Empty
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_not_null_valid()
        {
            RequiredIfOtherNotNullIsValidTest model = new()
            {
                Value = string.Empty
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }
    }
}
