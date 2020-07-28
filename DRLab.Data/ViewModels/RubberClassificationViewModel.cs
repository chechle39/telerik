using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class RubberClassificationViewModel
    {
        public string Denominator { get; set; }
        [Display(Name = "Dirt")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Dirt { get; set; }
        [Display(Name = "Ash")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Ash { get; set; }
        [Display(Name = "Steam")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Steam { get; set; }
        [Display(Name = "Protein")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Protein { get; set; }
        [Display(Name = "Po")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Po { get; set; }
        [Display(Name = "PRI")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> PRI { get; set; }
        [Display(Name = "Color")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> Color { get; set; }
        [Display(Name = "MOONEY")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public Nullable<int> MOONEY { get; set; }
    }
}
