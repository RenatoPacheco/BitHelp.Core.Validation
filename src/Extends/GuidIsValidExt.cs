﻿using System;
using System.Linq.Expressions;
using BitHelp.Core.Extend;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Extends
{
    public static class GuidIsValidExt
    {
        public static ValidationNotification GuidEhValido<TClasse>(
            this ValidationNotification source, TClasse data, Expression<Func<TClasse, object>> expression)
        {
            string prorpety = expression.PropertyTrail();
            object value = expression.PropertyInfo().GetValue(data);
            string display = expression.PropertyDisplay();
            return source.GuidEhValido(value, display, prorpety);
        }

        public static ValidationNotification GuidEhValido(
            this ValidationNotification notificacao, object value)
        {
            return notificacao.GuidEhValido(value, Resource.Value, null);
        }

        private static ValidationNotification GuidEhValido(
            this ValidationNotification source, object value, string display, string reference)
        {
            source.LastMessage = null;
            GuidIsValidAttribute validation = new GuidIsValidAttribute();
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
