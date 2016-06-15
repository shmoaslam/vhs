using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyAdditionalInfo : Base
    {
        [Key]
        public int id { get; set; }
        public string PropDescription { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string IsPetsAllowed { get; set; }
        public string IsDrinikingAllowed { get; set; }
        public string IsSmokingAllowed { get; set; }
        public string IsWheelChairAccess { get; set; }
        public string IsFamKidFriendAllowed { get; set; }
        public int PersonPerRoom { get; set; }

        public string PropertyRating { get; set; }
        public int MaxGuest { get; set; }

        public string MapLatitude { get; set; }
        public string MapLongitude { get; set; }
        public string PropertySize { get; set; }
        public int CancellationPolicy { get; set; }

        public int? MininumStay { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
