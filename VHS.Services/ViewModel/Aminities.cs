using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.ViewModel
{
    public class BathRommsModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedBathRoomsModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] BathRoomsIds { get; set; }
    }

    public class ParkingModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedParkingModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] ParkingIds { get; set; }
    }

    public class SleepingArrangmentModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedSleepingArrangmentModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] SleepArrangmentIds { get; set; }
    }

    public class KitchenModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedKitchenModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] KitchenIds { get; set; }
    }

    public class GeneralModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedGeneralModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] GeneralIds { get; set; }
    }

    public class EnterTaimentElecModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PostedEnterTaimentElecModel
    {
        //this array will be used to POST values from the form to the controller
        public string[] EnterTaimentElecIds { get; set; }
    }

    //public class ParkingModel
    //{
    //    public int id { get; set; }
    //    public string Name { get; set; }
    //    public bool IsChecked { get; set; }
    //}
    //public class PostedParkingModel
    //{
    //    //this array will be used to POST values from the form to the controller
    //    public string[] ParkingIds { get; set; }
    //}
}
