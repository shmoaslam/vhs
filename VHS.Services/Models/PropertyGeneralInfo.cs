using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Models
{
    public class PropertyGeneralInfo : Property
    {
        public int PropertyId { get; set; }
        public double PricePerNight { get; set; }
        public double PricePerWeek { get; set; }
    }
}
