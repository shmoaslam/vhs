using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class UserLogin : Base
    {
        [Key]
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }

        //StdId is not following code first conventions name
        public  UserProfile UserProfile { get; set; }

        public  ICollection<Document> Document { get; set; }

        public int TypeId { get; set; }
        //[ForeignKey("TypeId")]
        public UserType UserType { get; set; }
    }
}
