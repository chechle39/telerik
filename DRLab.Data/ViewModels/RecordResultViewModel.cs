using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.ViewModels
{
    public class RecordResultGridViewModel
    {
        public string WOID { get; set; }
        [Display(Name = "Specification")]
        public string specification { get; set; }
        [Display(Name = "Method")]
        public string method { get; set; }
        [Display(Name = "Mark")]
        public string Mark { get; set; }
        [Display(Name = "LOD")]
        public string LOD { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }
        [Display(Name = "Result")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<float> Result { get; set; }
        [Display(Name = "ResultText")]
        public string ResultText { get; set; }
        [Display(Name = "ExpectationDate")]
        public DateTime? ExpectationDate { get; set; }
        [Display(Name = "ReviewResult")]
        public int? ReviewResult { get; set; }
        public string LVNCode { get; set; }
        public string AnalysisCode { get; set; }
        public int? ValidationResult { get; set; }
        public string SpecCode { get; set; }
    }

    public class SearchRecordResult 
    {
        public string requestNo { get; set; }
        //public string sampleCode { get; set; }
        //public string inLabCode { get; set; }
    }

    public class GetRecordResult
    {
        public List<RecordResultGridViewModel> Data { get; set; }
        public string requestNo { get; set; }
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }
        public string weight { get; set; }
        public string remarkToLab { get; set; }
        public string SampleMatrix { get; set; }
    }
}
