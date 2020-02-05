﻿using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualItensIsValidExt
    {
        public static ValidationNotification EqualItensIsValid<TClass>(
            this ValidationNotification source, TClass data, Expression<Func<TClass, IList>> expression,
                Expression<Func<TClass, IList>> compare, params Expression<Func<TClass, IList>>[] compareMore)
            where TClass : class
        {
            IList<IList> values = new List<IList>();

            values.Add(expression.Compile().DynamicInvoke(data) as IList);
            values.Add(compare.Compile().DynamicInvoke(data) as IList);

            foreach (var item in compareMore)
            {
                values.Add(item.Compile().DynamicInvoke(data) as IList);
            }
            return source.EqualItensIsValid(values);
        }

        public static ValidationNotification EqualItensIsValid(
            this ValidationNotification source, IList value, IList compare, params IList[] compareMore)
        {
            compareMore = compareMore.Concat(new IList[] { value, compare }).ToArray();
            return source.EqualItensIsValid(compareMore);
        }

        private static ValidationNotification EqualItensIsValid(
            this ValidationNotification source, IEnumerable<IList> value)
        {
            bool result = true;
            int? total = null;
            bool isnull = false;
            
            foreach (var item in value)
            {
                if(item != null)
                {
                    if(isnull)
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
                    isnull = true;
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
                string text = Resource.EqualNumberItensInvalid;
                var message = new ValidationMessage(text, null);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}