using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace VHS.Services.ViewModel
{
    public class ProfileViewModel
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? Anniversary { get; set; }
        public TravelPreferenceViewModel TravelPreferenceObj { get; set; }
        public string WorkTelephone { get; set; }
        public string HomeTelephone { get; set; }
        public bool IsVerified { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public HttpPostedFile Document { get; set; }

        public int PrefContactId { get; set; }
        public SelectList PrefContactMethod { get; set; }

        public int CallTimeId { get; set; }
        public SelectList PrefCalltime { get; set; }
    }
    public class TravelPreferences
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
    public class TravelPreferenceViewModel
    {
        public IEnumerable<TravelPreferences> AvailableTravelPreference { get; set; }
        public IEnumerable<TravelPreferences> SelectedravelPreference { get; set; }
        public PostedTravelPreference PostedTravelPreference { get; set; }
    }
    public class PostedTravelPreference
    {
        //this array will be used to POST values from the form to the controller
        public string[] TravelPrefIds { get; set; }
    }
    public class ddlPreferContact
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlCallTime
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
