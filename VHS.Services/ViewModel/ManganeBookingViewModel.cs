using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
   public class ManganeBookingViewModel
    {
        public int Id { get; set; }
        public string PropertyId { get; set; }
        public string BookingId { get; set; }
        public string Name { get; set; }
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public bool IsCustomerIdAvailable { get; set; }

        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public string UserComment { get; set; }

        public decimal QuotedPrice { get; set; }
        public decimal NegotiatePrice { get; set; }
        public decimal RecievedPayment { get; set; }

        public string PropertyDisplayName { get; set; }

        public string RmComment { get; set; }


    }
}
