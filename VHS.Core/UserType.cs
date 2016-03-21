using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHS.Core
{
    public class UserType : Base
    {
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
    }
}
