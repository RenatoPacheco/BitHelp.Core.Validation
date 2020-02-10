using BitHelp.Core.Validation.Notations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Xunit;
using System;

namespace BitHelp.Core.Validation.Test.NotationsTest
{
    public class ComparePlusDateTimeIsValidTest
    {
        [ComparePlusDateTimeIsValid(nameof(Compare))]
        public DateTime? Value { get; set; }

        public DateTime? Compare { get; set; }

        readonly DateTime _value = DateTime.Now;

        [Fact]
        public void Check_all_null_valid()
        {
            var model = new ComparePlusDateTimeIsValidTest();
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_compare_null_valid()
        {
            var model = new ComparePlusDateTimeIsValidTest()
            {
                Value = _value.AddMinutes(123),
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
            var model = new ComparePlusDateTimeIsValidTest()
            {
                Value = null,
                Compare = _value.AddMinutes(123)
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void Check_value_less_invalid()
        {
            var model = new ComparePlusDateTimeIsValidTest()
            {
                Value = _value.AddMinutes(123),
                Compare = _value.AddMinutes(456)
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_equal_invalid()
        {
            var model = new ComparePlusDateTimeIsValidTest()
            {
                Value = _value.AddMinutes(123),
                Compare = _value.AddMinutes(123)
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void Check_value_plus_valid()
        {
            var model = new ComparePlusDateTimeIsValidTest()
            {
                Value = _value.AddMinutes(456),
                Compare = _value.AddMinutes(123)
            };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.True(isValid);
        }
    }
}
