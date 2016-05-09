using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace VHS.Services.Models
{
    public class Property
    {
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter no. of guest")]
        [Range(1, int.MaxValue,ErrorMessage ="Value must be grater than zero")]
        public int NoOfGuests { get; set; }
        [Required(ErrorMessage = "Please enter no. of room")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public int NoOfRooms { get; set; }
        [Required(ErrorMessage = "Please enter no. of bathroom")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public int NoOfBathrooms { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please select region")]
        public int RegionId { get; set; }
        public SelectList Region { get; set; }
        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter zipcode")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please choose category")]
        public int CategoryId { get; set; }
        public SelectList Category { get; set; }
        [Required(ErrorMessage = "Please choose list")]
        public int ListById { get; set; }
        public SelectList ListBy { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your contact no.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter valid contact no.")]
        public string ContactNo { get; set; }
        //[Required(ErrorMessage = "Please upload image")]
        public HttpPostedFile Image { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be grater than zero")]
        public int Price { get; set; }
    }
    public class ddlCategory
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlListedBy
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class ddlRegion
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
