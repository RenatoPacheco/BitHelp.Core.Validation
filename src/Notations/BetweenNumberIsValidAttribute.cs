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
        private BetweenNumberIsValidAttribute (bool denay, IList options)
            : base()
        {
            if ((options?.Count ?? 0) <= 0)
                throw new ArgumentException(string.Format(
                    Resource.XNullOrEmpty, nameof(options)), nameof(options));

            ErrorMessageResourceName = nameof(Resource.XNotValid);
            Denay = denay;
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<float> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(float);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<double> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(double);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<decimal> options, bool denay = false) 
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(decimal);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<byte> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(byte);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<sbyte> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(sbyte);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<short> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(short);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<ushort> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(ushort);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<int> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(int);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<uint> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(uint);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<long> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(long);
        }

        public BetweenNumberIsValidAttribute(
            IEnumerable<ulong> options, bool denay = false)
            : this(denay, options as IList)
        {
            Options = options.Select(x => x as dynamic);
            Type = typeof(ulong);
        }

        IEnumerable<dynamic> Options { get; set; } = Array.Empty<dynamic>();

        bool Denay { get; set; }

        Type Type { get; set; }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            bool isNumber = false;
            bool contains = false;

            if (Type == typeof(float))
            {
                isNumber = float.TryParse(input, out float compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(double))
            {
                isNumber = double.TryParse(input, out double compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(decimal))
            {
                isNumber = decimal.TryParse(input, out decimal compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(byte))
            {
                isNumber = byte.TryParse(input, out byte compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(sbyte))
            {
                isNumber = sbyte.TryParse(input, out sbyte compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(short))
            {
                isNumber = short.TryParse(input, out short compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(ushort))
            {
                isNumber = ushort.TryParse(input, out ushort compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(int))
            {
                isNumber = int.TryParse(input, out int compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(uint))
            {
                isNumber = uint.TryParse(input, out uint compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(long))
            {
                isNumber = long.TryParse(input, out long compare);
                contains = Options.Contains(compare);
            }
            else if (Type == typeof(ulong))
            {
                isNumber = ulong.TryParse(input, out ulong compare);
                contains = Options.Contains(compare);
            }

            return isNumber && (Denay ? !contains : contains);
        }
    }
}
