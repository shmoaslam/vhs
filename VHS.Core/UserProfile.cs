using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHS.Core
{
    public class UserProfile
    {

        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? Anniversary { get; set; }
        public string TravelPreferences { get; set; }
        public string WorkTelephone { get; set; }
        public string HomeTelephone { get; set; }
        public string PrefMethodContact { get; set; }
        public string PrefCallTime { get; set; }
        public bool IsVerified { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        [Key]
        public int LoginId { get; set; }
        public  UserLogin UserLogin { get; set; }

    }
}
