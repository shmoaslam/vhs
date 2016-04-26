using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class Newsletter : BaseProperty
    {
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
