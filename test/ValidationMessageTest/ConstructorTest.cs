using BitHelp.Core.Validation.Test.Resources;
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
                throw new CustonException(message, stackTrace);
            }
            catch (CustonException ex)
            {
                ValidationMessage result = new(ex, reference, type);

                Assert.Equal(result.Message, expected);
                Assert.Equal(result.Type, type);
                Assert.Equal(result.Reference, reference);

            }
        }
    }
}
