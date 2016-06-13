using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyBooking: Base
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
   
        [ForeignKey("UserLogin")]
        public int LoginId { get; set; }
        public UserLogin UserLogin { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int GuestCount { get; set; }
        public int ChildCount { get; set; }
        public int AdultCount { get; set; }
        public decimal AproxPrice { get; set; }

        public string UserComments { get; set; }
        public string RmComment { get; set; }
        public bool? IsCustomerIdCollected { get; set; }

        public decimal? NegoPric { get; set; }
        public decimal? RemainPrice { get; set; }
    }
}
