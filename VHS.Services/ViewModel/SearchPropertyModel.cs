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
        public int Guest { get; set; }
        public string StartDate { get; set; }
        public string PropertyUID { get; set; }
        public string EndDate { get; set; }

        public bool IsAdvancedSearch { get; set; }
        public int[] BathRoomsId { get; set; }
        public int[] ParkingId { get; set; }
        public int[] SleepingArrangmentId { get; set; }
        public int[] KitchenId { get; set; }
        public int[] GeneralId { get; set; }
        public int[] EnterTaimentId { get; set; }
        public int[] OutdoorId { get; set; }

    }
}
