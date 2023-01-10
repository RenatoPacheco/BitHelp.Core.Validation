using System;
using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class SingleValues : ISelfValidation
    {
        public object Value { get; set; }

        public object Compare { get; set; }

        public object Object { get; set; }

        public char Char { get; set; }

        public string String { get; set; }

        public byte Byte { get; set; }

        [Display(Name = "Byte null")]
        public byte? ByteNull { get; set; }

        public sbyte Sbyte { get; set; }

        [Display(Name = "Sbyte null")]
        public sbyte? SbyteNull { get; set; }

        public int Int { get; set; }

        [Display(Name = "Int null")]
        public int? IntNull { get; set; }

        public long Long { get; set; }

        [Display(Name = "Long null")]
        public long? LongNull { get; set; }

        public ulong Ulong { get; set; }

        [Display(Name = "Ulong null")]
        public ulong? UlongNull { get; set; }

        public decimal Decimal { get; set; }

        [Display(Name = "Decimal null")]
        public decimal? DecimalNull { get; set; }

        public double Double { get; set; }

        [Display(Name = "Double null")]
        public double? DoubleNull { get; set; }

        public float Float { get; set; }

        [Display(Name = "Float null")]
        public float? FloatNull { get; set; }

        public short Short { get; set; }

        [Display(Name = "Short null")]
        public short? ShortNull { get; set; }

        public ushort Ushort { get; set; }

        [Display(Name = "Ushort null")]
        public ushort? UshortNull { get; set; }

        public uint Uint { get; set; }

        [Display(Name = "Uint null")]
        public uint? UintNull { get; set; }

        [Display(Name = "Date time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Date time null")]
        public DateTime? DateTimeNull { get; set; }

        [Display(Name = "Time span")]
        public TimeSpan TimeSpan { get; set; }

        [Display(Name = "Time span null")]
        public TimeSpan? TimeSpanNull { get; set; }

        public Guid Guid { get; set; }

        [Display(Name = "Guid null")]
        public Guid? GuidNull { get; set; }

        public bool Bool { get; set; }

        [Display(Name = "Bool null")]
        public bool? BoolNull { get; set; }

        public EnumValue Enum { get; set; }

        [Display(Name = "Enum null")]
        public EnumValue? EnumNull { get; set; }

        public ValidationNotification Notifications { get; private set; } = new();

        public bool IsValid() => Notifications.IsValid();
    }
}
