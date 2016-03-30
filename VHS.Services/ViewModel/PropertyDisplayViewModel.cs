using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class PropertyDisplayViewModel
    {
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
    }
}
