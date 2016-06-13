using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class SearchPropertyModel
    {
        public string Query { get; set; }
        public int Category { get; set; }
        public int Region { get; set; }
    }
}
