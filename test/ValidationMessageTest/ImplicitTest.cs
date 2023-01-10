using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ValidationMessageTest
{
    public class ImplicitTest
    {
        #region string

        [Fact]
        public void Check_implicit_validationMessage_to_string()
        {
            ValidationMessage value = new("Text");
            string compare = value;

            Assert.Equal(value.Message, compare);
        }

        [Fact]
        public void Check_implicit_validationMessage_to_string_null()
        {
            ValidationMessage value = null;
            string compare = value;

            Assert.Null(compare);
        }

        [Fact]
        public void Check_implicit_string_to_validationMessage()
        {
            string value = "Text";
            ValidationMessage compare = value;

            Assert.Equal(value, compare.Message);
        }

        [Fact]
        public void Check_implicit_string_to_validationMessage_null()
        {
            string value = null;
            ValidationMessage compare = value;

            Assert.Null(compare);
        }

        #endregion

        #region exception

        [Fact]
        public void Check_implicit_validationMessage_to_exception()
        {
            ValidationMessage value = new(new Exception("Text"));
            Exception compare = value;

            Assert.Equal(value.Message, compare.Message);
        }

        [Fact]
        public void Check_implicit_validationMessage_to_exception_null()
        {
            ValidationMessage value = null;
            Exception compare = value;

            Assert.Null(compare);
        }

        [Fact]
        public void Check_implicit_exception_to_validationMessage()
        {
            Exception value = new Exception("Text");
            ValidationMessage compare = value;

            Assert.Equal(value.Message, compare.Message);
        }

        [Fact]
        public void Check_implicit_exception_to_validationMessage_null()
        {
            Exception value = null;
            ValidationMessage compare = value;

            Assert.Null(compare);
        }

        #endregion
    }
}
