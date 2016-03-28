using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyOutdoorMap : Base
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey("OutdoorFacilities")]
        public int OutFaciId { get; set; }
        public OutdoorFacilities OutdoorFacilities { get; set; }
    }
}
