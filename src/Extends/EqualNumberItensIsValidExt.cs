using BitHelp.Core.Validation.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitHelp.Core.Validation.Extends
{
    public static class EqualNumberItensIsValidExt
    {
        public static ValidationNotification EqualNumberItensIsValid<TClasse>(
            this ValidationNotification source, TClasse data, string reference, Expression<Func<TClasse, IList>> expression,
                Expression<Func<TClasse, IList>> expressionCompare, params Expression<Func<TClasse, IList>>[] expressionList)
            where TClasse : class
        {
            IList<IList> values = new List<IList>();

            values.Add(expression.Compile().DynamicInvoke(data) as IList);
            values.Add(expressionCompare.Compile().DynamicInvoke(data) as IList);

            foreach (var item in expressionList)
            {
                values.Add(item.Compile().DynamicInvoke(data) as IList);
            }
            return source.EqualNumberItensIsValid(reference, values);
        }

        public static ValidationNotification EqualNumberItensIsValid(
            this ValidationNotification source, string reference, IList value, IList valueCompare, params IList[] valueList)
        {
            valueList = valueList.Concat(new IList[] { value, valueCompare }).ToArray();
            return source.EqualNumberItensIsValid(reference, valueList);
        }

        private static ValidationNotification EqualNumberItensIsValid(
            this ValidationNotification source, string reference, IEnumerable<IList> value)
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
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
