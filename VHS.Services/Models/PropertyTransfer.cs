using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VHS.Services.ViewModel;

namespace VHS.Services.Models
{
    public class PropertyTransfer
    {
        public int PropertyId { get; set; }
        [Required(ErrorMessage = "Please choose rm")]
        public int RmId { get; set; }
        public SelectList SelectedRm { get; set; }
    }
}
