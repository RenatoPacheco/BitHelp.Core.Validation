﻿using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenDateTimeIsValidAttribute : ListIsValidAttribute
    {
        public BetweenDateTimeIsValidAttribute(
            IEnumerable<DateTime> options, 
            CultureInfo cultureInfo = null,
            bool denay = false) : base()
        {
            if (!options?.Any() ?? true)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);

            Options = options.Select(x => DateTime.Parse(x.ToString()));
            CultureInfo = cultureInfo;
            Denay = denay;
        }

        IEnumerable<DateTime> Options { get; set; } = Array.Empty<DateTime>();

        bool Denay { get; set; }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is DateTime check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                CultureInfo format = CultureInfo ?? CultureInfo.CurrentCulture;
                DateTimeStyles style = DateTimeStyles.None;
                isValueValid = DateTime.TryParse(Convert.ToString(value), format, style, out DateTime convert);
                contains = Options.Contains(convert);
            }

            return isValueValid && (Denay ? !contains : contains);
        }
    }
}
