using System;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualItemsIsValidExt
    {
        #region To ISelfValidation

        public static ValidationNotification EqualItemsIsValid<T>(
            this T source, Expression<Func<T, IEnumerable>> expression,
                Expression<Func<T, IEnumerable>> compare, params Expression<Func<T, IEnumerable>>[] compareMore)
            where T : ISelfValidation
        {
            IList<IEnumerable> values = new List<IEnumerable>
            {
                expression.Compile().DynamicInvoke(source) as IEnumerable,
                compare.Compile().DynamicInvoke(source) as IEnumerable
            };

            foreach (Expression<Func<T, IEnumerable>> item in compareMore)
            {
                values.Add(item.Compile().DynamicInvoke(source) as IEnumerable);
            }
            return source.Notifications.EqualItemsIsValid(values);
        }

        public static ValidationNotification EqualItemsIsValid(
            this ISelfValidation source, IEnumerable value, IEnumerable compare, params IEnumerable[] compareMore)
        {
            compareMore = compareMore.Concat(new IEnumerable[] { value, compare }).ToArray();
            return source.Notifications.EqualItemsIsValid(compareMore);
        }

        #endregion

        public static ValidationNotification EqualItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IEnumerable>> expression,
                Expression<Func<T, IEnumerable>> compare, params Expression<Func<T, IEnumerable>>[] compareMore)
        {
            IList<IEnumerable> values = new List<IEnumerable>
            {
                expression.Compile().DynamicInvoke(data) as IEnumerable,
                compare.Compile().DynamicInvoke(data) as IEnumerable
            };

            foreach (Expression<Func<T, IEnumerable>> item in compareMore)
            {
                values.Add(item.Compile().DynamicInvoke(data) as IEnumerable);
            }
            return source.EqualItemsIsValid(values);
        }

        public static ValidationNotification EqualItemsIsValid(
            this ValidationNotification source, IEnumerable value, IEnumerable compare, params IEnumerable[] compareMore)
        {
            compareMore = compareMore.Concat(new IEnumerable[] { value, compare }).ToArray();
            return source.EqualItemsIsValid(compareMore);
        }

        private static ValidationNotification EqualItemsIsValid(
            this ValidationNotification source, IEnumerable<IEnumerable> value)
        {
            bool result = true;
            int? total = null;
            bool isNull = false;
            
            foreach (IList item in value)
            {
                if(item != null)
                {
                    if(isNull)
                    {
                        result = false;
                        break;
                    }

                    int current = item.Count;
                    if (total == null)
                    {
                        total = current;
                    }
                    else if (current != total)
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    isNull = true;
                    if (total != null)
                    {
                        result = false;
                        break;
                    }
                }
            }

            source.CleanLastMessage();
            if (!result)
            {
                string text = Resource.EqualNumberItemsInvalid;
                ValidationMessage message = new ValidationMessage(text, null);
                source.SetLastMessage(message, Resource.DisplayValue);
                source.Add(message);
            }
            return source;
        }
    }
}
