using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class Image : Base
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
    }
}
