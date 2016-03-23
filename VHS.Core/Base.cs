using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class Base
    {
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public Base()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
            IsActive = true;
        }
    }
}
