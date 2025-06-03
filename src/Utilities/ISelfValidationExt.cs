using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BitHelp.Core.Validation.Utilities {

    public static class ISelfValidationExt {

        public static void RegisterError(
            this ValidationNotification source,
            IStructureToValidate data, string text) {
            text = string.Format(text, data.Display);
            var message = new ValidationMessage(text, data.Reference);
            source.SetLastMessage(message, data.Display);
            source.Add(message);
        }

        public static void RegisterError(
            this ValidationNotification source,
            IStructureToValidate data,
            ValidationAttribute validation) {
            string text = validation.FormatErrorMessage(data.Display);
            var message = new ValidationMessage(text, data.Reference);
            source.SetLastMessage(message, data.Display);
            source.Add(message);
        }
    }
}
