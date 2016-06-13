using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Models
{
    public class PropertyBooking
    {
        public int PropertyId { get; set; }
        [Required(ErrorMessage = "Please select start date")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please select end date")]
        public DateTime? EndDate { get; set; }
        public int GuestNo { get; set; }

        public int AdultNo { get; set; }

        public int ChildNo { get; set; }

        public decimal? AprroxPrice { get; set; }
    }
}
