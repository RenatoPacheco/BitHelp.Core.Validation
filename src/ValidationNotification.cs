using System;
using System.Linq;
using BitHelp.Core.Extend;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation
{
    public class ValidationNotification
    {
        public IList<ValidationMessage> Messages { get; set; } = new List<ValidationMessage>();

        public void Add(
           string message, ValidationType type = ValidationType.Error, 
           string reference = null)
        {
            this.Messages.Add(new ValidationMessage(message, reference, type));
        }

        public void Add<T>(
            Expression<Func<T, object>> expression, string message = null, 
            ValidationType type = ValidationType.Error, string reference = null)
        {
            string display = expression.PropertyDisplay();

            reference = reference ?? expression.PropertyTrail();

            message = message ?? Resource.XNotValid;
            message = Regex.Replace(message, @"\{0\}", display);

            this.Messages.Add(new ValidationMessage(message, reference, type));
        }

        public void Add<T>(
            Expression<Func<T, object>> expression, 
            ValidationType type, string reference = null)
        {
            this.Add(expression, null, type, reference);
        }

        public bool AnyEror()
        {
            return this.Messages.Any(x => x.IsError());
        }

        public void Clear()
        {
            this.Messages.Clear();
        }
    }
}
