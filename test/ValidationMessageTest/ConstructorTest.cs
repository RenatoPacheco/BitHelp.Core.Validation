using BitHelp.Core.Validation.Test.Resources;
using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ValidationMessageTest
{
    public class ConstructorTest
    {
        [Theory]
        [InlineData(null, null, null, ValidationType.Error, "Exception")]
        [InlineData(null, "Stack Trace", null, ValidationType.Error, "Stack Trace")]
        [InlineData("Message", "Stack Trace", null, ValidationType.Error, "Message")]
        public void Check_exception_values(
            string message, string stackTrace,
            string reference, ValidationType type, string expected)
        {
            try
            {
                throw new CustomException(message, stackTrace);
            }
            catch (CustomException ex)
            {
                ValidationMessage result = new(ex, reference, type);

                Assert.Equal(result.Message, expected);
                Assert.Equal(result.Type, type);
                Assert.Equal(result.Reference, reference);

            }
        }

        [Fact]
        public void Check_text_exception()
        {
            Exception error = null;

            try
            {
                throw new Exception("Text");
            }
            catch (Exception ex)
            {
                error = ex;
            }

            ValidationMessage value = new ValidationMessage(error);
            Assert.Equal("Text", value.Message);
        }

        [Fact]
        public void Check_text_null_exception()
        {
            Exception error = null;

            try
            {
                throw new Exception(null);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            ValidationMessage value = new ValidationMessage(error);
            Assert.NotEqual("Text", value.Message);
        }

        [Fact]
        public void Check__null_exception()
        {
            Exception error = null;

            ValidationMessage value = new ValidationMessage(error);
            Assert.Equal("Exception", value.Message);
        }

        [Theory]
        [InlineData(ValidationType.Fatal, ValidationCode.InternalServerError)]
        [InlineData(ValidationType.Error, ValidationCode.BadRequest)]
        [InlineData(ValidationType.Unauthorized, ValidationCode.Unauthorized)]
        [InlineData(ValidationType.Unauthenticated, ValidationCode.Unauthorized)]
        [InlineData(ValidationType.Forbidden, ValidationCode.Forbidden)]
        [InlineData(ValidationType.NotFound, ValidationCode.NotFound)]
        [InlineData(ValidationType.Alert, ValidationCode.Accepted)]
        [InlineData(ValidationType.Success, ValidationCode.OK)]
        [InlineData(ValidationType.Info, ValidationCode.OK)]
        [InlineData(ValidationType.Empty, ValidationCode.NoContent)]
        public void Check_validation_code_mapping(ValidationType type, ValidationCode expectedCode)
        {
            ValidationMessage value = new ValidationMessage("Test message", type);
            Assert.Equal(expectedCode, value.Code);
            Assert.Equal(type, value.Type);
        }

        [Fact]
        public void Check_validation_code_for_fatal_with_exception()
        {
            Exception error = new Exception("Fatal error");
            ValidationMessage value = new ValidationMessage(error, null, ValidationType.Fatal);
            Assert.Equal(ValidationCode.InternalServerError, value.Code);
            Assert.Equal(ValidationType.Fatal, value.Type);
        }

        [Fact]
        public void Check_validation_code_for_notfound()
        {
            ValidationMessage value = new ValidationMessage("Resource not found", null, ValidationType.NotFound);
            Assert.Equal(ValidationCode.NotFound, value.Code);
            Assert.Equal(ValidationType.NotFound, value.Type);
            Assert.Equal("Resource not found", value.Message);
        }

        [Fact]
        public void Check_is_type_error_for_unauthenticated_and_forbidden()
        {
            Assert.True(new ValidationMessage("Message", ValidationType.Unauthenticated).IsTypeError());
            Assert.True(new ValidationMessage("Message", ValidationType.Forbidden).IsTypeError());
            Assert.False(new ValidationMessage("Message", ValidationType.Alert).IsTypeError());
        }

        [Fact]
        public void Check_unauthenticated_and_forbidden_have_different_codes()
        {
            ValidationMessage unauthenticated = new ValidationMessage("Message", ValidationType.Unauthenticated);
            ValidationMessage forbidden = new ValidationMessage("Message", ValidationType.Forbidden);
            Assert.NotEqual(unauthenticated.Code, forbidden.Code);
        }
    }
}
