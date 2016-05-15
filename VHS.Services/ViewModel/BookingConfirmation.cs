using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class BookingConfirmation
    {
        public string Property { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AdminEmail { get; set; }
        public string RmEmail { get; set; }
        public string Mobile { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
