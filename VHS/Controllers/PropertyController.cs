using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Interface;
using VHS.Models;
using VHS.Services.Interface;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    [Authorize]
    [CustomException]
    public class PropertyController : Controller
    {
        private IProperty _property;
        private IPropertyBooking _propertyBooking;
        public PropertyController(IProperty property, IPropertyBooking propBooking)
        {
            _property = property;
            _propertyBooking = propBooking;
        }

        [AllowAnonymous]
        public ActionResult Add()
        {
            if (Request.IsAuthenticated)
            {
                var property = new Property();
                property.Category = GetCategory();
                property.ListBy = GetListBy();
                return View(property);
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult Add(Property property, List<HttpPostedFileBase> Image)
        {
            var proper = _property.AddProperty(property, Image);
            if (proper)
            {
                ViewBag.Message = "Property added sucessfully";
            }
            else
            {
                ViewBag.Message = "Error occured during property add.Please try later.";
            }

            return RedirectToAction("Add");
            //return View();
        }
        public SelectList GetCategory()
        {
            var lstCategory = new List<ddlCategory>();
            lstCategory.Add(new ddlCategory { Value = 1, Text = "Apartment" });
            lstCategory.Add(new ddlCategory { Value = 2, Text = "Beach House" });
            lstCategory.Add(new ddlCategory { Value = 3, Text = "Boat House" });
            lstCategory.Add(new ddlCategory { Value = 4, Text = "Farmhouse" });
            lstCategory.Add(new ddlCategory { Value = 5, Text = "Private Room" });
            lstCategory.Add(new ddlCategory { Value = 6, Text = "Villa" });
            lstCategory.Add(new ddlCategory { Value = 7, Text = "Other" });
            SelectList selesctedCategory = new SelectList(lstCategory, "Value", "Text");
            return selesctedCategory;
        }
        public SelectList GetListBy()
        {
            var lstListBy = new List<ddlListedBy>();
            lstListBy.Add(new ddlListedBy { Value = 1, Text = "Owner" });
            lstListBy.Add(new ddlListedBy { Value = 1, Text = "Representative" });
            SelectList selesctedListBy = new SelectList(lstListBy, "Value", "Text");
            return selesctedListBy;
        }
        [AllowAnonymous]
        public ActionResult Detail(int? id)
        {
            if (id == null) return View();
            var propertyViewModel = _property.GetPropertyDisplayModel(id);
            return View(propertyViewModel);
        }


        public class AvailbilityModel
        {
            public decimal Price { get; set; }
            public int Status { get; set; }
        }

        [AllowAnonymous]
        public JsonResult CheckAvailbility(string PropertyName, int PropertyId, string StartDate, string EndDate,
             int GuestNo, int AdultNo, int ChildNo, string ButtonType, decimal AprroxPrice)
        {
            var propBooking = new PropertyBooking
            {
                PropertyId = PropertyId,
                AdultNo = AdultNo,
                ChildNo = ChildNo,
                EndDate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                PropertyName = PropertyName,
                GuestNo = GuestNo,
                AprroxPrice = AprroxPrice
            };
            var response = new AvailbilityModel();


            if (propBooking.StartDate != null && propBooking.EndDate != null)
            {
                var checkAval = true;
                var bookProperty = true;

                if (ButtonType == "CA")
                {
                    checkAval = _propertyBooking.CheckPropertyAvailbility(propBooking);



                    if (!checkAval)
                    {
                        response.Status = 1;
                        var price = _propertyBooking.GetTotalPrice(propBooking);
                        response.Price = price.HasValue ? price.Value : 0;
                    }
                    else
                    {
                        response.Status = 2;
                    }
                }
                else if (ButtonType == "BP")
                {
                    if (Request.IsAuthenticated)
                    {
                        bookProperty = _propertyBooking.BookProperty(propBooking);
                        if (bookProperty)
                        {
                            response.Status = 3;
                        }
                        else
                        {
                            response.Status = 4;
                        }
                    }
                    else
                    {
                        response.Status = 6;

                    }
                }
                else
                {
                    response.Status = 5;
                }

            }

            return Json(response);

        }

        [AllowAnonymous]
        public JsonResult GetPropertyAutocompleteHelp(string query, string region)
        {
            List<string> autoCompleteHelp = _property.GetPropertyAutocompleteHelp(query, region);

            return Json(autoCompleteHelp);
        }
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ListedProperty(SearchPropertyModel model)
        {
            var propertyViewModel = _property.GetProperties(model);
            return View(propertyViewModel);
        }
        [AllowAnonymous]
        public ActionResult ListedSpainProperty(SearchPropertyModel model)
        {
            model.Region = 2;
            var propertyViewModel = _property.GetProperties(model);
            ViewBag.PropertyFrom = "Spain";
            return View("ListedProperty", propertyViewModel);
        }
        [AllowAnonymous]
        public ActionResult ListedIndianProperty(SearchPropertyModel model)
        {
            model.Region = 1;
            var propertyViewModel = _property.GetProperties(model);
            ViewBag.PropertyFrom = "India";
            return View("ListedProperty", propertyViewModel);
        }
    }
}