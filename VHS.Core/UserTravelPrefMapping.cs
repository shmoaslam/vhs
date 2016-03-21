using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class UserTravelPrefMapping : Base
    {
        public int Id { get; set; }

        [ForeignKey("TravelPreferences")]
        public int TravelPrefId { get; set; }
        public TravelPreferences TravelPreferences { get; set; }

        [ForeignKey("UserLogin")]
        public int LoginId { get; set; }
        public UserLogin UserLogin { get; set; }
    }
}
