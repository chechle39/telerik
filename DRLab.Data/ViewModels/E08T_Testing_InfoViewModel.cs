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
        [Display(Name = "Specification")]
        public string specification { get; set; }
        [Display(Name = "Method")]
        public string method { get; set; }
        [Display(Name = "Unit")]
        public string unit { get; set; }
        [Display(Name = "turnAround Time")]
        public double turnAroundTime { get; set; }
        [Display(Name = "reformTestResult")]
        public bool reformTestResult { get; set; }
        [Display(Name = "note")]
        public string note { get; set; }
    }   
}
