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
        public int PropertyId { get; set; }
        public int PropAdditionalId { get; set; }
        [Required(ErrorMessage = "Please enter property description")]
        public string PropertyDescription { get; set; }
        [Required(ErrorMessage = "Please enter checkin")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public string CheckIn { get; set; }
        [Required(ErrorMessage = "Please enter check out)")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public string CheckOut { get; set; }
        [Required(ErrorMessage = "Please enter property size")]
        public string PropertySize { get; set; }
        [Required(ErrorMessage = "Please enter perosn)")]
        public int PersonPerRoom { get; set; }

        [Required(ErrorMessage = "Please select option)")]
        public int PetsAllowedId { get; set; }
        public SelectList PetsAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)")]
        public int DrinkAllowedId { get; set; }
        public SelectList DrinkingAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)")]
        public int SmokeAllowedId { get; set; }
        public SelectList SmokeAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)")]
        public int FamilyKidAllowedId { get; set; }
        public SelectList FamilyKidAllowed { get; set; }

        [Required(ErrorMessage = "Please enter perosn)")]
        public int WheelChairId { get; set; }
        public SelectList WheelChairAllowed { get; set; }

        public List<BlakOutDate> BlackOutDatsList { get; set; }

        [Required(ErrorMessage = "Please enter latitude)")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter longitude)")]
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

    public class BlakOutDate
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class PropertyAmenities
    {
        public int PropertyId { get; set; }
        public int PropAmenitiesId { get; set; }
        public int[] BathRoomsId { get; set; }
        public IEnumerable<BathRommsModel> BathRoomsList { get; set; }
        public int[] ParkingId { get; set; }
        public IEnumerable<ParkingModel> ParkingList { get; set; }
        public int[] SleepingArrangmentId { get; set; }
        public IEnumerable<SleepingArrangmentModel> SleepingArrangmentList { get; set; }
        public int[] KitchenId { get; set; }
        public IEnumerable<KitchenModel> KitchenList { get; set; }
        public int[] GeneralId { get; set; }
        public IEnumerable<GeneralModel> GeneralList { get; set; }
        public int[] EnterTaimentId { get; set; }
        public IEnumerable<EnterTaimentElecModel> EnterTaimentElecList { get; set; }
        public int[] OutdoorId { get; set; }
        public IEnumerable<OutdoorFacilitiesModel> OutdoorFacilitiesList { get; set; }
    }

    public class PropertyFixedPricing
    {
        public int PropertyId { get; set; }
        public int PropFixedPriceId { get; set; }
        [Required(ErrorMessage = "Please select option")]
        public int CurrencyId { get; set; }
        public SelectList PriceCurrency { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PricePerNight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PricePerWeek { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PricePerMonth { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double CleaningFeeDaily { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double CleaningFeeWeekly { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double CleaningFeeMonthly { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PriceOneTime { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double OtherPrice { get; set; }
    }
    public class PropertyVarablePricing
    {
        public int PropertyId { get; set; }
        public int PropVarPriceId { get; set; }
        [Required(ErrorMessage = "Please select start date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please select stop date")]
        public DateTime StopDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
    }
    public class ddlPriceCurrency
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
