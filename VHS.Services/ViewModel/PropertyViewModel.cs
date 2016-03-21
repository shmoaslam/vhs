using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class PropertyViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string ShortInfo { get; set; }
        public List<ImageViewModel> PropertImageList { get; set; }
        public bool IsApproved { get; set; }

    }
}
