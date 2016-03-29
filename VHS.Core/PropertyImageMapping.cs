using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyImageMapping : Base
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Image")]
        public int ImageId { get; set; }
        public Image Image { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
