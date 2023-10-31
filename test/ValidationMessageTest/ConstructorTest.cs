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
    }
}
