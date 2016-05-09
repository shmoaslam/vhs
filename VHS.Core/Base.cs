using System;
using System.Web;
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
            if (CreatedBy == null && UpdatedBy == null)
            {
                CreatedBy = 1;
                UpdatedBy = 1;
            }
            IsActive = true;
        }
    }
}
