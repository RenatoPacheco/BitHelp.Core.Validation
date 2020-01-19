using System;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class SingleValues
    {
        public char Char { get; set; }

        public string String { get; set; }

        public int Int { get; set; }

        [Display(Name = "Int null")]
        public int? IntNull { get; set; }

        public long Long { get; set; }

        [Display(Name = "Long null")]
        public long? LongNull { get; set; }

        public decimal Decimal { get; set; }

        [Display(Name = "Decimal null")]
        public decimal? DecimalNull { get; set; }

        public double Double { get; set; }

        [Display(Name = "Double null")]
        public double? DoubleNull { get; set; }

        public uint Uint { get; set; }

        [Display(Name = "Uint null")]
        public uint? UintNull { get; set; }

        [Display(Name = "Date time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Date time null")]
        public DateTime? DateTimeNull { get; set; }

        public Guid Guid { get; set; }

        [Display(Name = "Guid null")]
        public Guid? GuidNull { get; set; }

        public bool Bool { get; set; }

        [Display(Name = "Bool null")]
        public bool? BoolNull { get; set; }

        public EnumValue Enum { get; set; }

        [Display(Name = "Enum null")]
        public EnumValue? EnumNull { get; set; }
    }
}
