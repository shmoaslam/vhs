using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class BaseProperty : Base
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
