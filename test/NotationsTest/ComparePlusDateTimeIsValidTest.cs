using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class ComparePlusDateTimeIsValidValue01Test
    {
        [ComparePlusDateTimeIsValid("", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusDateTimeIsValidValue02Test
    {
        [ComparePlusDateTimeIsValid("Invalid", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class ComparePlusDateTimeIsValidValue03Test
    {
        [ComparePlusDateTimeIsValid(nameof(Compare))]
        public object Value { get; set; }

        public object Compare { get; set; }
    }


    public class ComparePlusDateTimeIsValidTest
    {
        [ComparePlusDateTimeIsValid(nameof(Compare), "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "12/25/2020")]
        [InlineData("12/26/2020", null)]
        [InlineData("12/26/2020", "12/25/2020")]
        [InlineData("not valid date", "12/25/2020")]
        [InlineData("12/26/2020", "not valid date")]
        public void Check_format_is_valid(
            object input, object compare)
        {
            ComparePlusDateTimeIsValidTest model = new()
            {
                Value = input,
                Compare = compare
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("12/25/2020", "12/26/2020")]
        public void Check_format_is_invalid(
            object input, object compare)
        {
            ComparePlusDateTimeIsValidTest model = new()
            {
                Value = input,
                Compare = compare
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_property_unll_or_empty_invalid()
        {
            ComparePlusDateTimeIsValidValue01Test model = new()
            {
                Value = "12/26/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<ArgumentException>(() => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_invalid()
        {
            ComparePlusDateTimeIsValidValue02Test model = new()
            {
                Value = "12/26/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(() => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_culture_info_as_null_valid()
        {
            ComparePlusDateTimeIsValidValue03Test model = new()
            {
                Value = DateTime.Now.AddDays(2).ToString(),
                Compare = DateTime.Now.ToString()
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }
    }
}
