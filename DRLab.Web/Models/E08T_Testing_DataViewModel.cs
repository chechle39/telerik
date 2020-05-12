using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Web.Models
{
    public class E08T_Testing_DataViewModel
    {
        [Display(Name = "Testing ID")]
        public Nullable<long> iD { get; set; }
        [Display(Name = "Simple Matrix ID")]
        public Nullable<long> matrixID { get; set; }
        [Display(Name = "Specification ID")]
        public Nullable<long> specID { get; set; }
        [Display(Name = "Min")]
        public double min { get; set; }
        [Display(Name = "Max")]
        public double max { get; set; }
        [Display(Name = "Precision")]
        public double precision { get; set; }
        [Display(Name = "LOD")]
        public string LOD { get; set; }
    }
}
