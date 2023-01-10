using System;
using Xunit;

namespace BitHelp.Core.Validation.Test.ValidationMessageTest
{
    public class OperatorTest
    {
        [Theory]
        [InlineData("Text", "other", ValidationType.Unauthorized, true)]
        [InlineData("Text 2", "other", ValidationType.Unauthorized, false)]
        [InlineData("Text", "other-2", ValidationType.Unauthorized, false)]
        [InlineData("Text", "other", ValidationType.Error, false)]
        public void Check_equal(string message, string reference, ValidationType type, bool isEqual)
        {
            ValidationMessage value = new("Text", "other", ValidationType.Unauthorized);
            ValidationMessage compare = new(message, reference, type);
            object other = compare;

            Assert.Equal(isEqual, value == compare);
            Assert.Equal(!isEqual, value != compare);

            Assert.Equal(isEqual, value.Equals(other));

            value = null;

            Assert.True(value != compare);
            Assert.False(value == compare);

            Assert.True(compare != value);
            Assert.False(compare == value);

            Assert.False(other.Equals(value));

            compare = null;

            Assert.False(value != compare);
            Assert.True(value == compare);
        }

        [Fact]
        public void Check_GetHashCode_is_unique()
        {
            ValidationMessage value = new("Text", ValidationType.Success);
            ValidationMessage compare = new("Text", ValidationType.Success);

            Assert.False(value.GetHashCode() == compare.GetHashCode());

            compare = value;

            Assert.True(value.GetHashCode() == compare.GetHashCode());
        }
    }
}
