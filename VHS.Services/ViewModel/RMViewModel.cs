using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class RMViewModel
    {
        public int RMId { get; set; }
        public string RMName { get; set; }
        public bool IsApproved { get; set; }
    }
    public class ddlRM
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
