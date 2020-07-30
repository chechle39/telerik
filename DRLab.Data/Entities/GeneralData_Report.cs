using System;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.Entities
{
    public partial class GeneralData_Report
    {
        [Key]
        public long ID { get; set; }
        public string requestNo { get; set; }
        public string sampleCode { get; set; }
        public string sampleMatrix { get; set; }
        public string specCode { get; set; }
        public string Mark { get; set; }
        public Nullable<double> Value { get; set; }
        public string Rank { get; set; }
    }
}
