using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VHS.Services
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter contact no.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        [Remote("CheckEmailExist", "Account", ErrorMessage = "Email id already registered")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public bool bEmailVerified { get; set; }
        public bool bTermsCondition { get; set; }
    }
}
