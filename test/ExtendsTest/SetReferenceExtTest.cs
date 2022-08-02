using Xunit;
using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SetReferenceExtTest
    {
        private readonly ValidationNotification _notification = new();

        [Fact]
        public void Check_set_reference_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string reference = "New reference";

            _notification.Clear();
            _notification.LongIsValid(single.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_null_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string reference = null;

            _notification.Clear();
            _notification.LongIsValid(single.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_empty_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string reference = string.Empty;

            _notification.Clear();
            _notification.LongIsValid(single.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(reference, _notification.Messages[0].Reference);
        }


        [Fact]
        public void Check_set_reference_empty_with_space_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };
            string reference = "         ";

            _notification.Clear();
            _notification.LongIsValid(single.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(string.Empty, _notification.Messages[0].Reference);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetReference(reference);

            Assert.False(_notification.IsValid());
            Assert.Equal(string.Empty, _notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_expression_valid()
        {
            SingleValues single = new()
            {
                String = "number"
            };

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                    .SetReference<SingleValues>(x => x.Bool);

            Assert.False(_notification.IsValid());
            Assert.Equal(nameof(single.Bool), _notification.Messages[0].Reference);

            _notification.Clear();
            _notification.LongIsValid(single, x => x.String)
                .SetReference(single, x => x.Bool);

            Assert.False(_notification.IsValid());
            Assert.Equal(nameof(single.Bool), _notification.Messages[0].Reference);
        }
    }
}
