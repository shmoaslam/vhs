using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VHS.Services.ViewModel;

namespace VHS.Services.Models
{
    public class PropertyAdditionalInfoModel
    {
        [Required(ErrorMessage = "Please enter property description")]
        public string PropertyDescription { get; set; }
        [Required(ErrorMessage = "Please enter checkin")]
        public TimeSpan CheckIn { get; set; }
        [Required(ErrorMessage = "Please enter check out)]")]
        public TimeSpan CheckOut { get; set; }
        [Required(ErrorMessage = "Please enter property size)]")]
        public TimeSpan PropertySize { get; set; }
        [Required(ErrorMessage = "Please enter perosn)]")]
        public int PersonPerRoom { get; set; }

        [Required(ErrorMessage = "Please select option)]")]
        public int PetsAllowedId { get; set; }
        public SelectList PetsAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)]")]
        public int DrinkAllowedId { get; set; }
        public SelectList DrinkingAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)]")]
        public int SmokeAllowedId { get; set; }
        public SelectList SmokeAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)]")]
        public int FamilyKidAllowedId { get; set; }
        public SelectList FamilyKidAllowed { get; set; }

        [Required(ErrorMessage = "Please enter perosn)]")]
        public int WheelChairId { get; set; }
        public SelectList WheelChairAllowed { get; set; }

        public IEnumerable<BathRommsModel> BathRoomsList { get; set; }
        public IEnumerable<ParkingModel> ParkingList { get; set; }
        public IEnumerable<SleepingArrangmentModel> SleepingArrangmentList { get; set; }
        public IEnumerable<KitchenModel> KitchenList { get; set; }
        public IEnumerable<GeneralModel> GeneralList { get; set; }
        public IEnumerable<EnterTaimentElecModel> EnterTaimentElecList { get; set; }
        public IEnumerable<OutdoorFacilitiesModel> OutdoorFacilitiesList { get; set; }

        [Required(ErrorMessage = "Please enter latitude)]")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter longitude)]")]
        public string Logitude { get; set; }

    }
    public class ddlCallTime
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlPetsAllowed
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlDrinkingAllowed
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlSmokingAllowed
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlFamilyKidAllowed
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlWheelChailAccessible
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
