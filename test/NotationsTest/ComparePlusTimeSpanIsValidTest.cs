using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class ComparePlusTimeSpanIsValidNamePropNullTest
    {
        [ComparePlusTimeSpanIsValid(null, "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusTimeSpanIsValidNamePropEmptyTest
    {
        [ComparePlusTimeSpanIsValid("", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusTimeSpanIsValidNamePropInvalidTest
    {
        [ComparePlusTimeSpanIsValid("Invalid", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusTimeSpanIsValidCultureInfoInvalidTest
    {
        [ComparePlusTimeSpanIsValid(nameof(Compare), "Invalid")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusTimeSpanIsValidTest
    {
        [ComparePlusTimeSpanIsValid(nameof(Compare), "en-US")]
        public TimeSpan? Value { get; set; }

        public TimeSpan? Compare { get; set; }

        [Fact]
        public void Check_all_null_valid()
        {
            ComparePlusTimeSpanIsValidTest model = new();
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            ComparePlusTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = null
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_null_valid()
        {
            ComparePlusTimeSpanIsValidTest model = new()
            {
                Value = null,
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_less_invalid()
        {
            ComparePlusTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            ComparePlusTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_plus_valid()
        {
            ComparePlusTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_property_null_name_invalid()
        {
            ComparePlusTimeSpanIsValidNamePropNullTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_empty_name_invalid()
        {
            ComparePlusTimeSpanIsValidNamePropEmptyTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_name_invalid()
        {
            ComparePlusTimeSpanIsValidNamePropInvalidTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_culture_info_invalid()
        {
            ComparePlusTimeSpanIsValidCultureInfoInvalidTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<ArgumentException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }
    }
}
