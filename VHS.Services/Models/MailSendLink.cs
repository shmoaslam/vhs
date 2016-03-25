using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Models
{
    public class MailSendLink
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool LinkUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
