using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Interface;
using VHS.Services.Models;

namespace VHS.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        private IProperty _property;
        public PropertyController(IProperty property)
        {
            _property = property;
        }
        public ActionResult Add()
        {
            var property = new Property();
            property.Category = GetCategory();
            property.ListBy = GetListBy();
            return View(property);
        }
        [HttpPost]
        public ActionResult Add(Property property, List<HttpPostedFileBase> Image)
        {
           var proper= _property.AddProperty(property, Image);
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

            return View();
        }
    }

}