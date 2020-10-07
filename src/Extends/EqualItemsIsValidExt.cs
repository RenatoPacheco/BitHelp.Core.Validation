using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualItemsIsValidExt
    {
        public static ValidationNotification EqualItemsIsValid<T>(
            this ValidationNotification source, T data, Expression<Func<T, IList>> expression,
                Expression<Func<T, IList>> compare, params Expression<Func<T, IList>>[] compareMore)
            where T : class
        {
            IList<IList> values = new List<IList>
            {
                expression.Compile().DynamicInvoke(data) as IList,
                compare.Compile().DynamicInvoke(data) as IList
            };

            foreach (var item in compareMore)
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
            
            foreach (var item in value)
            {
                if(item != null)
                {
                    if(isNull)
                    {
                        result = false;
                        break;
                    }

                    int current = (item as IList).Count;
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

            source.LastMessage = null;
            if (!result)
            {
                string text = Resource.EqualNumberItemsInvalid;
                var message = new ValidationMessage(text, null);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
