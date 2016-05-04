using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VHS.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        public string Email { get; set; }
    }
}