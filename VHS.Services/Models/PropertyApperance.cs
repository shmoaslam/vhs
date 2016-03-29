using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VHS.Services.Models
{
    public class PropertyCoverPhoto
    {
        public int PropertyId { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public HttpPostedFile CoverPhoto { get; set; }
    }
    public class PropertyGallaryPhoto
    {
        public int PropertyId { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public HttpPostedFile GallaryPhoto { get; set; }
    }
}
