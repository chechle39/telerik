using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E00T_SpecificationViewModel
    {
        [Display(Name = "Spec ID")]
        public Nullable<long> specID { get; set; }
        [Display(Name = "Specification")]
        public string specification { get; set; }
    }
}
