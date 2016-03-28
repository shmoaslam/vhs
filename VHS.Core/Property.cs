using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class Property : Base
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfGuest { get; set; }
        public int NumberOfBathRoom { get; set; }
        public int Price { get; set; }
        public bool IsApproved { get; set; }
        public int NumberOfRooms { get; set; }

        public double PricePerNight { get; set; }
        public double PricePerWeek { get; set; }
        public Nullable<int> LocalOrder { get; set; }

        [ForeignKey("UserLogin")]
        public int LoginId { get; set; }
        public UserLogin UserLogin { get; set; }

        [ForeignKey("PropertyCategory")]
        public int CategoryId { get; set; }
        public PropertyCategory PropertyCategory { get; set; }

        [ForeignKey("PropertyListedBy")]
        public int ListedId { get; set; }
        public PropertyListedBy PropertyListedBy { get; set; }
    }
}
