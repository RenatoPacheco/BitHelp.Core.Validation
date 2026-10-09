using BitHelp.Core.Extend;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends {

    /// <summary>
    /// Extension methods to inherit notifications from child ISelfValidation objects.
    /// </summary>
    public static class InheritItemNotificationsExt {

        /// <summary>
        /// Inherits notifications from a single child ISelfValidation object.
        /// Validates the child object and adds its notifications to the parent with the property path as reference prefix.
        /// </summary>
        /// <typeparam name="T">The parent type that implements ISelfValidation.</typeparam>
        /// <typeparam name="P">The child property type that implements ISelfValidation.</typeparam>
        /// <param name="source">The parent object.</param>
        /// <param name="expression">Expression to access the child property.</param>
        public static void InheritItemNotifications<T, P>(this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
            where P : ISelfValidation {

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var reference = expression.PropertyPath();
            var value = expression.Compile().Invoke(source);

            if (value != null) {
                value.IsValid();
                source.Notifications.Add(value, reference);
            }
        }

        /// <summary>
        /// Inherits notifications from a collection of ISelfValidation objects.
        /// Validates each child object and adds its notifications to the parent with indexed reference prefix.
        /// </summary>
        /// <typeparam name="T">The parent type that implements ISelfValidation.</typeparam>
        /// <typeparam name="P">The collection type containing ISelfValidation items.</typeparam>
        /// <param name="source">The parent object.</param>
        /// <param name="expression">Expression to access the collection property.</param>
        public static void InheritItemsNotifications<T, P>(this T source, Expression<Func<T, P>> expression)
            where T : ISelfValidation
            where P : IEnumerable<ISelfValidation> {

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var reference = expression.PropertyPath();
            var values = expression.Compile().Invoke(source);

            if (values != null) {
                int index = 0;
                foreach (var value in values) {
                    if (value != null) {
                        string prefix = $"{reference}[{index}]";
                        value.IsValid();
                        source.Notifications.Add(value, prefix);
                    }
                    index++;
                }
            }
        }
    }
}
