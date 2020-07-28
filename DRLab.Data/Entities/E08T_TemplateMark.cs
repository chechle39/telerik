using System;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.Entities
{
    public partial class E08T_TemplateMark
    {
        [Key]
        public int Id { get; set; }
        public string AnalysisCode { get; set; }
        public string TenanId { get; set; }
        public string TemLateName { get; set; }
        public string Specification { get; set; }
        public string Method { get; set; }
        public string Mark { get; set; }
        public string LOD { get; set; }
        public string Unit { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Urgent { get; set; }
        public Nullable<double> TurnAroundDay { get; set; }
    }
}
