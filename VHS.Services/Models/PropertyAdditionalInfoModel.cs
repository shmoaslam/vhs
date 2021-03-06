﻿using System;
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
        public string CheckIn { get; set; }
        [Required(ErrorMessage = "Please enter check out")]
        public string CheckOut { get; set; }
        [Required(ErrorMessage = "Please enter property size")]
        public int PropertySize { get; set; }
        [Required(ErrorMessage = "Please enter perosn")]
        public int PersonPerRoom { get; set; }

        [Required(ErrorMessage = "Please select option")]
        public int PetsAllowedId { get; set; }
        public SelectList PetsAllowed { get; set; }

        [Required(ErrorMessage = "Please select option)")]
        public int DrinkAllowedId { get; set; }
        public SelectList DrinkingAllowed { get; set; }

        [Required(ErrorMessage = "Please select option")]
        public int SmokeAllowedId { get; set; }
        public SelectList SmokeAllowed { get; set; }

        [Required(ErrorMessage = "Please select option")]
        public int FamilyKidAllowedId { get; set; }
        public SelectList FamilyKidAllowed { get; set; }

        [Required(ErrorMessage = "Please enter perosn")]
        public int WheelChairId { get; set; }
        public SelectList WheelChairAllowed { get; set; }

        public List<BlakOutDate> BlackOutDatsList { get; set; }

        [Required(ErrorMessage = "Please enter latitude")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter longitude")]
        public string Logitude { get; set; }


        [Required(ErrorMessage = "Please select rating")]
        public int PropRatingId { get; set; }
        public SelectList ProperyRating { get; set; }



        [Required(ErrorMessage = "Please enter max guest ")]
        public int MaxGuest { get; set; }

        public int? MininumStay { get; set; }

        [Required(ErrorMessage = "Please select Cancellation Policy")]
        public int CancellationPolicyId { get; set; }
        public SelectList CancellationPolicy { get; set; }


    }

    public class ddlCancellationPolicy
    {
        public int Value { get; set; }
        public string Text { get; set; }
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
        public int BlackOutDateId { get; set; }
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
        [Required(ErrorMessage = "Please select start date")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please select stop date")]
        public DateTime? StopDate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PricePerNight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public double PricePerWeek { get; set; }
        public double PricePerMonth { get; set; }
        public double CleaningFeeDaily { get; set; }
        public double CleaningFeeWeekly { get; set; }
        public double CleaningFeeMonthly { get; set; }
        public double PriceOneTime { get; set; }
        public string OtherPrice { get; set; }
        public decimal Comision { get; set; }
        public decimal? PricePerAdult { get; set; }
        public decimal? PricePerChild { get; set; }
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


        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
    }
    public class PropertyWeekendPricing
    {
        public int PropertyId { get; set; }
        public int PropWEPriceId { get; set; }
        [Required(ErrorMessage = "Please select start date")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please select stop date")]
        public string To { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select start date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please select end date")]
        public DateTime? EndDate { get; set; }

        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
    }
    public class ddlPriceCurrency
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class ddlPropertyRating
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
