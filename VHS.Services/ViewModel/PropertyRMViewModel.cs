using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VHS.Services.ViewModel
{
    public class PropertyRMViewModel
    {
        public int hdnPropertyId { get; set; }
        public List<PropertyViewModel> proppertyVMList { get; set; }
        // public List<RMViewModel> rmList { get; set; }
        [Required(ErrorMessage = "Please choose rm")]
        public int RmId { get; set; }
        public List<ddlRM> RmList { get; set; }
        public SelectList SelectedRm { get; set; }
        public int hdnPropRMId { get; set; }
    }
}
