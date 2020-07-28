using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.Entities
{
    public class GenaralData_Report
    {
        [Key]
        public int ID { get; set; }
        public string requestNo { get; set; }
        public string sampleCode { get; set; }
        public string sampleMatrix { get; set; }
        public string specCode { get; set; }
        public string Mark { get; set; }
        public float Value { get; set; }
        public string Rank { get; set; }

    }
}
