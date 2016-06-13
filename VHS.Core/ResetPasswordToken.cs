using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class ResetPasswordToken : Base
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string Email { get; set; }
        public Guid Token { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
