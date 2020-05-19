using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DRLab.Data.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6,ErrorMessage = "{0} must be at least {1}.")]
        public string Password { get; set; }

        public bool IsRemember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
