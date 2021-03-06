﻿using System;
using System.Globalization;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class DateTimeIsValidAttribute : ListIsValidAttribute
    {
        public DateTimeIsValidAttribute(CultureInfo cultureInfo = null) : base()
        {
            ErrorMessageResourceName = nameof(Resource.XDateTimeInvalid);

            CultureInfo = cultureInfo;
        }

        /// <summary>
        /// Set CultureInfo but is null the value used will be CultureInfo.CurrentCulture
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            CultureInfo cultureInfo = CultureInfo ?? CultureInfo.CurrentCulture;
            return DateTime.TryParse(input, cultureInfo, DateTimeStyles.None, out _);
        }
    }
}
