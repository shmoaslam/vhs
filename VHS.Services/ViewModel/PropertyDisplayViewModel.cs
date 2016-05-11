using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Models;

namespace VHS.Services.ViewModel
{
    public class PropertyDisplayViewModel
    {
        public int Id { get; set; }
        public string CoverImage { get; set; }
        public string[] GalaryImages { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string IsPetAllowed { get; set; }
        public string IsDrinkingAllowed { get; set; }
        public string IsSmokingAllowed { get; set; }
        public string IsFamilyKidFriendly { get; set; }
        public string IsWheelchairAccessible { get; set; }
        public string PersonPerRoom { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int GuestCount { get; set; }

        public List<string> General { get; set; }
        public List<string> Parking { get; set; }
        public List<string> Outdoor { get; set; }
        public List<string> Bathroom { get; set; }
        public List<string> EntertainmentElectronic { get; set; }
        public List<string> SleepingArrangments { get; set; }
        public List<string> Kitchen { get; set; }
        public PropertyBooking objPropertyBooking { get; set; }

    }
}
