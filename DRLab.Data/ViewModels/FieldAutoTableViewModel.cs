using System;
using System.Collections.Generic;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class FieldAutoTableViewModel
    {
        public int ID { get; set; }
        public string SampleCode { get; set; }
        public string ColumName { get; set; }
        public Nullable<decimal> Value { get; set; }
        public int Denominator { get; set; }
        public string DKSVR { get; set; }
        public string requestNo { get; set; }
    }

    public class RubberClassification
    {
        public string ML { get; set; }
        public string Color { get; set; }
        public string PRI { get; set; }
        public string P0 { get; set; }
        public string Nitro { get; set; }
        public string Volatilematter { get; set; }
        public string Ash { get; set; }
        public string Dirt { get; set; }
    }
    public class RubberClassificationNum
    {
        public decimal ML { get; set; }
        public decimal Color { get; set; }
        public decimal PRI { get; set; }
        public decimal P0 { get; set; }
        public decimal Nitro { get; set; }
        public decimal Volatilematter { get; set; }
        public decimal Ash { get; set; }
        public decimal Dirt { get; set; }
    }

    public class ReportData
    {
        public string requestNo { get; set; }
        public string sampleCode { get; set; }
        public string sampleMatrix { get; set; }
        public string specCode { get; set; }
        public string Mark { get; set; }
        public string Value { get; set; }
        public string Rank { get; set; }
    }
}
