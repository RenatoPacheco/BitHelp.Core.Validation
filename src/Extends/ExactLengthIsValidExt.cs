using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class ExactLengthIsValidExt
    {
        public static ValidationNotification ExactLengthEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression, int exact)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data);
            string display = expression.PropertyDisplay();
            return source.ExactLengthEhValido(value, display, prorpety, exact);
        }

        public static ValidationNotification ExactLengthEhValido(
            this ValidationNotification notificacao, object value, int exact)
        {
            return notificacao.ExactLengthEhValido(value, Resource.Value, null, exact);
        }

        private static ValidationNotification ExactLengthEhValido(
            this ValidationNotification source, object value, string display, string reference, int exact)
        {
            source.LastMessage = null;
            ExactLengthIsValidAttribute validation = new ExactLengthIsValidAttribute(exact);
            if (!validation.IsValid(value))
            {
                string text = validation.FormatErrorMessage(display);
                var message = new ValidationMessage(text, reference);
                source.LastMessage = message;
                source.Add(message);
            }
            return source;
        }
    }
}
