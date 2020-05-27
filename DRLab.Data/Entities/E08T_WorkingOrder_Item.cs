using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRLab.Data.Entities
{
    public partial class E08T_WorkingOrder_Item
    { 
        
        public string WOID { get; set; }
        [Key]
        public string RequestNo { get; set; }
        public string LVNCode { get; set; }
        public string AnalysisCode { get; set; }
        public string Specification { get; set; }
        public string SampleMatrix { get; set; }
        public Nullable<System.DateTime> ExpectationDate { get; set; }
        public Nullable<double> Result { get; set; }
        public string Unit { get; set; }
        public string ReviewBy { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public Nullable<int> ReviewResult { get; set; }
        public Nullable<int> ValidationResult { get; set; }
        public Nullable<int> CheckFinal { get; set; }
        public Nullable<int> SaveTemp { get; set; }
        public string ValidationBy { get; set; }
        public Nullable<System.DateTime> ValidationDate { get; set; }
        public string CheckFinalBy { get; set; }
        public Nullable<System.DateTime> CheckFinalDate { get; set; }
        public string Note { get; set; }
        public string ResultText { get; set; }
        public string RecheckReason { get; set; }
        public string RejectReason { get; set; }
        public string TechComment { get; set; }
        public string Method { get; set; }
        public string LOD { get; set; }
        [ForeignKey("WOID")]
        public virtual E08T_WorkingOrder_Info E08T_WorkingOrder_Info { get; set; }
    }
}
