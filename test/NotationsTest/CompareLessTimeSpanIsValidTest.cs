using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class CompareLessTimeSpanIsValidNamePropNullTest
    {
        [CompareLessTimeSpanIsValid(null, "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessTimeSpanIsValidNamePropEmptyTest
    {
        [CompareLessTimeSpanIsValid("", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessTimeSpanIsValidNamePropInvalidTest
    {
        [CompareLessTimeSpanIsValid("Invalid", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessTimeSpanIsValidCultureInfoInvalidTest
    {
        [CompareLessTimeSpanIsValid(nameof(Compare), "Invalid")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessTimeSpanIsValidTest
    {
        [CompareLessTimeSpanIsValid(nameof(Compare), "en-US")]
        public TimeSpan? Value { get; set; }

        public TimeSpan? Compare { get; set; }

        [Fact]
        public void Check_all_null_valid()
        {
            CompareLessTimeSpanIsValidTest model = new();
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            CompareLessTimeSpanIsValidTest model = new()
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
            CompareLessTimeSpanIsValidTest model = new()
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
        public void Check_value_less_valid()
        {
            CompareLessTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            CompareLessTimeSpanIsValidTest model = new()
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
        public void Check_value_plus_invalid()
        {
            CompareLessTimeSpanIsValidTest model = new()
            {
                Value = TimeSpan.FromMinutes(456),
                Compare = TimeSpan.FromMinutes(123)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_property_null_name_invalid()
        {
            CompareLessTimeSpanIsValidNamePropNullTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_empty_name_invalid()
        {
            CompareLessTimeSpanIsValidNamePropEmptyTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_name_invalid()
        {
            CompareLessTimeSpanIsValidNamePropInvalidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_culture_info_invalid()
        {
            CompareLessTimeSpanIsValidCultureInfoInvalidTest model = new()
            {
                Value = TimeSpan.FromMinutes(123),
                Compare = TimeSpan.FromMinutes(456)
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<ArgumentException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }
    }
}
