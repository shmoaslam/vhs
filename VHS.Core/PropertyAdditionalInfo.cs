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
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public bool IsPetsAllowed { get; set; }
        public bool IsDrinikingAllowed { get; set; }
        public bool IsSmokingAllowed { get; set; }
        public bool IsWheelChairAccess { get; set; }
        public string MapLatitude { get; set; }
        public string MapLongitude { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
