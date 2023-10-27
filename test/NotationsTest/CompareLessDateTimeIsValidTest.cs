using Xunit;
using System;
using System.Collections.Generic;
using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class CompareLessDateTimeIsValidNamePropNullTest
    {
        [CompareLessDateTimeIsValid(null, "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessDateTimeIsValidNamePropEmptyTest
    {
        [CompareLessDateTimeIsValid("", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessDateTimeIsValidNamePropInvalidTest
    {
        [CompareLessDateTimeIsValid("Invalid", "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessDateTimeIsValidCultureInfoInvalidTest
    {
        [CompareLessDateTimeIsValid(nameof(Compare), "Invalid")]
        public object Value { get; set; }

        public object Compare { get; set; }
    }

    public class CompareLessDateTimeIsValidTest
    {
        [CompareLessDateTimeIsValid(nameof(Compare), "en-US")]
        public object Value { get; set; }

        public object Compare { get; set; }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "12/25/2020")]
        [InlineData("12/24/2020", null)]
        [InlineData("12/24/2020", "12/25/2020")]
        [InlineData("not valid date", "12/25/2020")]
        [InlineData("12/24/2020", "not valid date")]
        public void Check_format_is_valid(object input, object compare)
        {
            CompareLessDateTimeIsValidTest model = new()
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
        [InlineData("12/25/2020", "12/24/2020")]
        public void Check_format_is_invalid(object input, object compare)
        {
            CompareLessDateTimeIsValidTest model = new()
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
        public void Check_property_null_name_invalid()
        {
            CompareLessDateTimeIsValidNamePropNullTest model = new()
            {
                Value = "12/24/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(() 
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_empty_name_invalid()
        {
            CompareLessDateTimeIsValidNamePropEmptyTest model = new()
            {
                Value = "12/24/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(() 
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_property_name_invalid()
        {
            CompareLessDateTimeIsValidNamePropInvalidTest model = new()
            {
                Value = "12/24/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<NullReferenceException>(() 
                => Validator.TryValidateObject(model, context, results, true));
        }

        [Fact]
        public void Check_culture_info_invalid()
        {
            CompareLessDateTimeIsValidCultureInfoInvalidTest model = new()
            {
                Value = "12/24/2020",
                Compare = "12/25/2020"
            };
            ValidationContext context = new(model);
            List<ValidationResult> results = new();

            Assert.Throws<ArgumentException>(()
                => Validator.TryValidateObject(model, context, results, true));
        }
    }
}
