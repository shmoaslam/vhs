using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class MailLink : Base
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Linkused { get; set; }
    }
}
