using System;
using System.Globalization;

namespace BitHelp.Core.Validation.Helpers
{
    public static class TryParse
    {
        public static bool ToEnum(
            Type type, object value, out object output)
        {
            return ToEnum(type, value, false, out output);
        }

        public static bool ToEnum(
            Type type, object value,
            bool ignoreCase, out object output)
        {
            bool result = value is Enum;
            output = value;

            if (result && value != null)
            {
                result = value.GetType() == type;
            }
            else
            {
                string input = Convert.ToString(value);
                result = !string.IsNullOrWhiteSpace(input);

                if (result)
                {
                    try
                    {
                        output = Enum.Parse(type, input, ignoreCase);
                        result = Enum.IsDefined(type, output);
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }

            if (!result)
            {
                output = null;
            }

            return result;
        }

        public static bool ToDate(
            object value, CultureInfo cultureInfo, out DateTime output)
        {
            if (value != null)
            {
                if (value is DateTime check)
                {
                    output = check;
                    return true;
                }
                else
                {
                    return DateTime.TryParse(Convert.ToString(value),
                        cultureInfo ?? CultureInfo.CurrentCulture,
                        DateTimeStyles.None, out output);
                }
            }

            output = new DateTime();
            return false;
        }
    }
}
