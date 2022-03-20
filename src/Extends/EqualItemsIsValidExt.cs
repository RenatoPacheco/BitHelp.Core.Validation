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
            this T source, Expression<Func<T, IList>> expression,
                Expression<Func<T, IList>> compare, params Expression<Func<T, IList>>[] compareMore)
            where T : ISelfValidation
        {
            IList<IList> values = new List<IList>
            {
                expression.Compile().DynamicInvoke(source) as IList,
                compare.Compile().DynamicInvoke(source) as IList
            };

            foreach (Expression<Func<T, IList>> item in compareMore)
            {
                values.Add(item.Compile().DynamicInvoke(source) as IList);
            }
            return source.Notifications.EqualItemsIsValid(values);
        }

        public static ValidationNotification EqualItemsIsValid(
            this ISelfValidation source, IList value, IList compare, params IList[] compareMore)
        {
            compareMore = compareMore.Concat(new IList[] { value, compare }).ToArray();
            return source.Notifications.EqualItemsIsValid(compareMore);
        }

        #endregion

        public static ValidationNotification EqualItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression,
                Expression<Func<T, IList>> compare, params Expression<Func<T, IList>>[] compareMore)
        {
            IList<IList> values = new List<IList>
            {
                expression.Compile().DynamicInvoke(data) as IList,
                compare.Compile().DynamicInvoke(data) as IList
            };

            foreach (Expression<Func<T, IList>> item in compareMore)
            {
                values.Add(item.Compile().DynamicInvoke(data) as IList);
            }
            return source.EqualItemsIsValid(values);
        }

        public static ValidationNotification EqualItemsIsValid(
            this ValidationNotification source, IList value, IList compare, params IList[] compareMore)
        {
            compareMore = compareMore.Concat(new IList[] { value, compare }).ToArray();
            return source.EqualItemsIsValid(compareMore);
        }

        private static ValidationNotification EqualItemsIsValid(
            this ValidationNotification source, IEnumerable<IList> value)
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
