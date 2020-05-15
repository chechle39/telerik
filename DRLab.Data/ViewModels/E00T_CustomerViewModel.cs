using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E00T_CustomerViewModel
    {
        public string customerCode { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string companyAddress { get; set; }
        public string city { get; set; }
        public string note { get; set; }
    }

    public class E00T_CustomerGridViewModel
    {
        public string analysisCode { get; set; }
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
        [Display(Name = "Price")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Price { get; set; }
        [Display(Name = "Urgent")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Urgent { get; set; }
        [Display(Name = "TAT")]
        public string TAT { get; set; }
    }

    public class CreateCustomeRequest
    {
        public List<E00T_CustomerGridViewModel> Data { get; set; }
        //public CreateE08TAnalysisRequestItemCreate CreateAnalysisRequestItemCreate { get; set; }
        public string requestNo { get; set; }
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }
        public string weight { get; set; }
        public string remarkToLab { get; set; }
        public string sampleMatrix { get; set; }
        public string specification { get; set; }
    }

    public class CreateE08TAnalysisRequestItemCreate
    {
        public string requestNo { get; set; }
        public string LVNCode { get; set; }
        public string sampleCode { get; set; }
        public string sampleName { get; set; }
        public string sampleDescription { get; set; }
        public string weight { get; set; }
        public string remarkToLab { get; set; } 
    }
}
