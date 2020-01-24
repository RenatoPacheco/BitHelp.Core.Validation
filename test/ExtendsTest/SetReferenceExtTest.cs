using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class SetReferenceExtTest
    {
        readonly ValidationNotification notification = new ValidationNotification();

        [Fact]
        public void Check_set_reference_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string reference = "New reference";

            notification.Clear();
            notification.LongIsValid(single.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);

            notification.Clear();
            notification.LongIsValid(single, x => x.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_null_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string reference = null;

            notification.Clear();
            notification.LongIsValid(single.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);

            notification.Clear();
            notification.LongIsValid(single, x => x.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_empty_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string reference = string.Empty;

            notification.Clear();
            notification.LongIsValid(single.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);

            notification.Clear();
            notification.LongIsValid(single, x => x.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(reference, notification.Messages[0].Reference);
        }


        [Fact]
        public void Check_set_reference_empty_with_space_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };
            string reference = "         ";

            notification.Clear();
            notification.LongIsValid(single.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(string.Empty, notification.Messages[0].Reference);

            notification.Clear();
            notification.LongIsValid(single, x => x.String).SetReference(reference);

            Assert.False(notification.IsValid());
            Assert.Equal(string.Empty, notification.Messages[0].Reference);
        }

        [Fact]
        public void Check_set_reference_expression_valid()
        {
            var single = new SingleValues
            {
                String = "number"
            };

            notification.Clear();
            notification.LongIsValid(single, x => x.String)
                    .SetReference<SingleValues>(x => x.Bool);

            Assert.False(notification.IsValid());
            Assert.Equal(nameof(single.Bool), notification.Messages[0].Reference);

            notification.Clear();
            notification.LongIsValid(single, x => x.String)
                .SetReference(single, x => x.Bool);

            Assert.False(notification.IsValid());
            Assert.Equal(nameof(single.Bool), notification.Messages[0].Reference);
        }
    }
}
