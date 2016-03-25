using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services
{
    public class LoginViewModel
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
    public class UserInfo
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
