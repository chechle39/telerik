using System;
using System.ComponentModel.DataAnnotations;

namespace DRLab.Data.ViewModels
{
    public class E08T_Testing_InfoViewModel
    {
        [Display(Name = "Analysis Code")]
        public string analysisCode { get; set; }
       
        [Display(Name = "Spec ID")]
        public Nullable<long> specID { get; set; }
        [Required]
        [Display(Name = "Specification")]
        public string specification { get; set; }
        [Required]
        [Display(Name = "Method")]
        public string method { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }
        [Display(Name = "turnAround Time")]
        public double turnAroundTime { get; set; }
        
        public bool reformTestResult { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }
    }
    public class E08T_Testing_InfoViewModel1
    {
     
        [Display(Name = "Analysis Code")]
        public string analysisCode { get; set; }
        [Required]
        [Display(Name = "Spec ID")]
        [ScaffoldColumn(false)]
        public Nullable<long> specID { get; set; }
        [UIHint("GridForeignKey")]      
        [Required]
        [Display(Name = "Specification")]
        public string specification { get; set; }
        [Display(Name = "New Specification")]
        public string newspecification { get; set; }
        [Required]
        [Display(Name = "Method")]
        public string method { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }
        [Display(Name = "turnAround Time")]
        public double turnAroundTime { get; set; }

        public bool reformTestResult { get; set; }
        [Display(Name = "note")]
        public string note { get; set; }
    }
}
