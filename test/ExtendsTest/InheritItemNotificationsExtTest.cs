using BitHelp.Core.Validation.Extends;
using BitHelp.Core.Validation.Test.Resources;
using System;
using System.Collections.Generic;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest {
    public class InheritItemNotificationsExtTest {
        #region InheritItemNotifications - Single Object

        [Fact]
        public void InheritItemNotifications_Should_Inherit_Notifications_From_Valid_Child() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "valid@email.com",
                    Age = 25
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemNotifications_Should_Inherit_Notifications_From_Invalid_Child() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "invalid-email",
                    Age = 25
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(parent.Notifications.Messages);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Email");
        }

        [Fact]
        public void InheritItemNotifications_Should_Add_Child_Reference_Prefix() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = null,
                    Age = null
                }
            };

            // Act
            parent.IsValid();

            // Assert
            Assert.False(parent.Notifications.IsValid());
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Email");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");
        }

        [Fact]
        public void InheritItemNotifications_Should_Handle_Null_Child() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = null
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemNotifications_Should_Combine_Parent_And_Child_Errors() {
            // Arrange
            var parent = new ParentModel {
                Name = "AB", // Too short
                Child = new ChildModel {
                    Email = "invalid-email",
                    Age = 200 // Out of range
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(parent.Notifications.Messages);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Name");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Email");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");
        }

        [Fact]
        public void InheritItemNotifications_Should_Handle_Child_With_Nullable_Age_Null() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "valid@email.com",
                    Age = null // Nullable age is null
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid); // Age is required
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");
        }

        [Fact]
        public void InheritItemNotifications_Should_Handle_Child_With_Age_Zero() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "valid@email.com",
                    Age = 0 // Zero is out of range (1-150)
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");
        }

        [Fact]
        public void InheritItemNotifications_Should_Handle_Child_With_Negative_Age() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "valid@email.com",
                    Age = -5 // Negative age is out of range
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");
        }

        [Fact]
        public void InheritItemNotifications_Should_Throw_ArgumentNullException_When_Source_Is_Null() {
            // Arrange
            ParentModel parent = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                parent.InheritItemNotifications(x => x.Child));
        }

        [Fact]
        public void InheritItemNotifications_Should_Throw_ArgumentNullException_When_Expression_Is_Null() {
            // Arrange
            var parent = new ParentModel { Name = "Test" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                parent.InheritItemNotifications<ParentModel, ChildModel>(null));
        }

        #endregion

        #region InheritItemsNotifications - Collection

        [Fact]
        public void InheritItemsNotifications_Should_Inherit_Notifications_From_Valid_Children() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "child1@email.com", Age = 10 },
                    new ChildModel { Email = "child2@email.com", Age = 20 },
                    new ChildModel { Email = "child3@email.com", Age = 30 }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemsNotifications_Should_Inherit_Notifications_From_Invalid_Children() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid@email.com", Age = 10 },
                    new ChildModel { Email = "invalid-email", Age = 20 }, // Invalid email
                    new ChildModel { Email = "child3@email.com", Age = 200 } // Invalid age
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(parent.Notifications.Messages);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[1].Email");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[2].Age");
        }

        [Fact]
        public void InheritItemsNotifications_Should_Add_Indexed_Reference_Prefix() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = null, Age = null },
                    new ChildModel { Email = "", Age = -1 },
                    new ChildModel { Email = "invalid", Age = 300 }
                }
            };

            // Act
            parent.IsValid();

            // Assert
            Assert.False(parent.Notifications.IsValid());
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[0]"));
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[1]"));
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[2]"));
        }

        [Fact]
        public void InheritItemsNotifications_Should_Handle_Empty_Collection() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>()
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemsNotifications_Should_Handle_Null_Collection() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = null
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemsNotifications_Should_Handle_Collection_With_Null_Items() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid@email.com", Age = 10 },
                    null, // Null item
                    new ChildModel { Email = "child3@email.com", Age = 30 }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(parent.Notifications.Messages);
        }

        [Fact]
        public void InheritItemsNotifications_Should_Process_Multiple_Invalid_Items() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "invalid1", Age = 0 },
                    new ChildModel { Email = "invalid2", Age = -5 },
                    new ChildModel { Email = "invalid3", Age = 300 }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            var errorCount = parent.Notifications.Messages.Count;
            Assert.True(errorCount >= 3); // At least one error per item

            // Verify that errors from each item are present
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[0]"));
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[1]"));
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[2]"));
        }

        [Fact]
        public void InheritItemsNotifications_Should_Handle_Children_With_Null_Ages() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid1@email.com", Age = null },
                    new ChildModel { Email = "valid2@email.com", Age = null },
                    new ChildModel { Email = "valid3@email.com", Age = null }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid); // Age is required for all children
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[0].Age");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[1].Age");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[2].Age");
        }

        [Fact]
        public void InheritItemsNotifications_Should_Handle_Mixed_Valid_And_Null_Ages() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid1@email.com", Age = 25 },
                    new ChildModel { Email = "valid2@email.com", Age = null },
                    new ChildModel { Email = "valid3@email.com", Age = 30 }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.Single(parent.Notifications.Messages);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[1].Age");
        }

        [Fact]
        public void InheritItemsNotifications_Should_Throw_ArgumentNullException_When_Source_Is_Null() {
            // Arrange
            ParentModel parent = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                parent.InheritItemsNotifications(x => x.Children));
        }

        [Fact]
        public void InheritItemsNotifications_Should_Throw_ArgumentNullException_When_Expression_Is_Null() {
            // Arrange
            var parent = new ParentModel { Name = "Test" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                parent.InheritItemsNotifications<ParentModel, List<ChildModel>>(null));
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void Should_Inherit_From_Both_Single_And_Collection() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = "invalid-single",
                    Age = 25
                },
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid@email.com", Age = 10 },
                    new ChildModel { Email = "invalid-collection", Age = 20 }
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Email");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Children[1].Email");
        }

        [Fact]
        public void Should_Maintain_Correct_Error_Types() {
            // Arrange
            var parent = new ParentModel {
                Name = "Parent Name",
                Child = new ChildModel {
                    Email = null,
                    Age = null
                }
            };

            // Act
            parent.IsValid();

            // Assert
            Assert.All(parent.Notifications.Messages, message =>
                Assert.True(ValidationMessage.IsTypeError(message.Type)));
        }

        [Fact]
        public void Should_Handle_Complex_Scenario_With_Multiple_Error_Types() {
            // Arrange
            var parent = new ParentModel {
                Name = "X", // Too short
                Child = new ChildModel {
                    Email = "not-an-email", // Invalid format
                    Age = 0 // Out of range
                },
                Children = new List<ChildModel>
                {
                    new ChildModel { Email = "valid@email.com", Age = 50 },
                    new ChildModel { Email = "", Age = null }, // Empty email and null age
                    new ChildModel { Email = "invalid", Age = 999 } // Invalid email and age too high
                }
            };

            // Act
            var isValid = parent.IsValid();

            // Assert
            Assert.False(isValid);

            // Verify parent errors
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Name");

            // Verify child errors
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Email");
            Assert.Contains(parent.Notifications.Messages, m => m.Reference == "Child.Age");

            // Verify collection errors
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[1]"));
            Assert.Contains(parent.Notifications.Messages, m => m.Reference.StartsWith("Children[2]"));
        }

        [Fact]
        public void Should_Validate_Age_Boundaries() {
            // Arrange & Act & Assert

            // Test minimum boundary (1)
            var parent1 = new ParentModel {
                Name = "Test",
                Child = new ChildModel { Email = "test@email.com", Age = 1 }
            };
            Assert.True(parent1.IsValid());

            // Test maximum boundary (150)
            var parent2 = new ParentModel {
                Name = "Test",
                Child = new ChildModel { Email = "test@email.com", Age = 150 }
            };
            Assert.True(parent2.IsValid());

            // Test below minimum (0)
            var parent3 = new ParentModel {
                Name = "Test",
                Child = new ChildModel { Email = "test@email.com", Age = 0 }
            };
            Assert.False(parent3.IsValid());

            // Test above maximum (151)
            var parent4 = new ParentModel {
                Name = "Test",
                Child = new ChildModel { Email = "test@email.com", Age = 151 }
            };
            Assert.False(parent4.IsValid());
        }

        #endregion
    }
}
