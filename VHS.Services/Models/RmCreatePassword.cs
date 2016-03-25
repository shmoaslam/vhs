using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Models
{
    public class RmCreatePassword
    {
        public int RmId { get; set; }
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
        public bool IsLinkUsed { get; set; }
        public int MailLinkId { get; set; }
    }
}
