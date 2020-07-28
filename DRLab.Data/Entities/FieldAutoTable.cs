using System;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.Entities
{
    public partial class FieldAutoTable
    {
        public FieldAutoTable(string columName, int denominator, int iD, decimal? value)
        {
            ColumName = columName;
            Denominator = denominator;
            ID = iD;
            Value = value;
        }

        [Key]
        public int ID { get; set; }
        public string SampleCode { get; set; }
        public string ColumName { get; set; }
        public Nullable<decimal> Value { get; set; }
        public int Denominator { get; set; }
    }
}
