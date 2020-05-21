using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E00T_CustomerViewModel
    {
        [Required]
        [Display(Name = "Customer Code")]
        public string customerCode { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string contactName { get; set; }
        [Required]
        [Display(Name = "Contact Email")]
        public string contactEmail { get; set; }
        [Required]
        [Display(Name = "Company Address")]
        public string companyAddress { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Note")]
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
        public Nullable<double> min { get; set; }
        public Nullable<double> max { get; set; }
        public string sampleMatrix { get; set; }
    }

    public class CreateCustomeRequest
    {
        public List<E00T_CustomerGridViewModel> Data { get; set; }
        public List<E00T_CustomerGridViewModel> Deleted { get; set; }
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
