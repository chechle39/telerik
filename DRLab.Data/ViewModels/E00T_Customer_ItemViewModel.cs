using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class E00T_Customer_ItemViewModel
    {
        [Display(Name = "Contact ID")]
        public long contactID { get; set; }
        [Required]
        [Display(Name = "Customer Code")]
        public string customerCode { get; set; }
        [Required]
        [Display(Name = "Contact Name")]
        public string contactName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }
    }
}
