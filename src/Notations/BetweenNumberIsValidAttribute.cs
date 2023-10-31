using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class BetweenNumberIsValidAttribute : ListIsValidAttribute
    {
        private BetweenNumberIsValidAttribute (bool deny, IList options)
            : base()
        {
            if ((options?.Count ?? 0) <= 0)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);
            Deny = deny;
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<float> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(float);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<double> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(double);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<decimal> options, bool deny = false) 
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(decimal);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<byte> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(byte);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<sbyte> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(sbyte);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<short> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(short);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<ushort> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(ushort);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<int> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(int);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<uint> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(uint);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<long> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(long);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<ulong> options, bool deny = false)
            : this(deny, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(ulong);
        }

        IEnumerable<dynamic> Options { get; set; } = Array.Empty<dynamic>();

        bool Deny { get; set; }

        Type Type { get; set; }

        protected override bool Check(object value)
        {
            bool isValueValid = false;
            bool contains = false;

            if (Type == typeof(float))
            {
                (isValueValid, contains) = CheckFloat(value);
            }
            else if (Type == typeof(double))
            {
                (isValueValid, contains) = CheckDouble(value);
            }
            else if (Type == typeof(decimal))
            {
                (isValueValid, contains) = CheckDecimal(value);
            }
            else if (Type == typeof(byte))
            {
                (isValueValid, contains) = CheckByte(value);
            }
            else if (Type == typeof(sbyte))
            {
                (isValueValid, contains) = CheckSbyte(value);
            }
            else if (Type == typeof(short))
            {
                (isValueValid, contains) = CheckShort(value);
            }
            else if (Type == typeof(ushort))
            {
                (isValueValid, contains) = CheckUshort(value);
            }
            else if (Type == typeof(int))
            {
                (isValueValid, contains) = CheckInt(value);
            }
            else if (Type == typeof(uint))
            {
                (isValueValid, contains) = CheckUint(value);
            }
            else if (Type == typeof(long))
            {
                (isValueValid, contains) = CheckLong(value);
            }
            else if (Type == typeof(ulong))
            {
                (isValueValid, contains) = CheckUlong(value);
            }

            return !isValueValid || (Deny ? !contains : contains);
        }

        private (bool isValueValid, bool contains) CheckFloat(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is float check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = float.TryParse(Convert.ToString(value), out float convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckDouble(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is double check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = double.TryParse(Convert.ToString(value), out double convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckDecimal(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is decimal check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = decimal.TryParse(Convert.ToString(value), out decimal convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckByte(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is byte check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = byte.TryParse(Convert.ToString(value), out byte convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckSbyte(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is sbyte check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = sbyte.TryParse(Convert.ToString(value), out sbyte convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckShort(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is short check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = short.TryParse(Convert.ToString(value), out short convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckUshort(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is ushort check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = ushort.TryParse(Convert.ToString(value), out ushort convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckInt(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is int check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = int.TryParse(Convert.ToString(value), out int convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckUint(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is uint check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = uint.TryParse(Convert.ToString(value), out uint convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckLong(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is long check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = long.TryParse(Convert.ToString(value), out long convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }

        private (bool isValueValid, bool contains) CheckUlong(object value)
        {
            bool isValueValid;
            bool contains;

            if (value is ulong check)
            {
                isValueValid = true;
                contains = Options.Contains(check);
            }
            else
            {
                isValueValid = ulong.TryParse(Convert.ToString(value), out ulong convert);
                contains = Options.Contains(convert);
            }

            return (isValueValid, contains);
        }
    }
}
