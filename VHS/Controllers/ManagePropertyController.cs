using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Interface;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    public class ManagePropertyController : BaseController
    {
        private IManageProperty _manageProperty;

        public object UrlReferrer { get; private set; }

        // GET: ManageProperty
        public ManagePropertyController(IManageProperty manageProperty)
        {
            _manageProperty = manageProperty;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Approve()
        {
            return View();
        }
        public ActionResult Waiting()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Assign()
        {
            var assignProperty = _manageProperty.GetAssignedProperty();
            return View(assignProperty);
        }
        [HttpGet]
        public ActionResult Assigned()
        {
            var assignProperty = _manageProperty.GetAssignedProperty();
            return View(assignProperty);
        }
        [HttpPost]
        public ActionResult Assign(PropertyRMViewModel proprmView)
        {
            var result = _manageProperty.SetPropertyToRm(proprmView);
            if (result)
            {
                return Json("1");
            }
            else
            {
                return Json("2");
            }


        }
        public ActionResult ManageProperty()
        {
            if (IsRM)
            {
                int rmId = CurrentUser.LoginId;
                var propertList = _manageProperty.GetPropertyForManage(rmId);
                return View(propertList);
            }
            else
            {
                var propertList = _manageProperty.GetPropertyForManage(0);
                return View(propertList);
            }
        }

        [HttpGet]
        public ActionResult EditProperty(int id)
        {
            var propGenralInfo = _manageProperty.GetPropertyDetail(id);
            return View(propGenralInfo);
        }

        [HttpPost]
        public ActionResult PropertyGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> Image)
        {
            var proper = _manageProperty.UpdateGeneralInfo(propGeneralInfo, Image);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public JsonResult PropertyAdditionalInfo(PropertyAdditionalInfoModel propAdditionalInfo)
        {
            var proper = _manageProperty.UpdateAdditionalInfo(propAdditionalInfo);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult PropertyAmenities(PropertyAmenities propAmenities)
        {
            var proper = _manageProperty.UpdateAmenities(propAmenities);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult PropertyFixedPricing(PropertyFixedPricing propFixPrice)
        {
            var proper = _manageProperty.UpdatePropFixPrice(propFixPrice);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult PropertyVariablePricing(PropertyVarablePricing propVarablePrice)
        {
            var proper = _manageProperty.UpdatePropVariablePrice(propVarablePrice);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public ActionResult PropertyCoverPhoto(PropertyCoverPhoto propertyCoverPhoto, IEnumerable<HttpPostedFileBase> CoverPhoto)
        {
            if (CoverPhoto == null)
            {
                return Json("0");
            }
            var proper = false;
           // var proper = _manageProperty.UpdatePropCoverPhoto(propertyCoverPhoto, CoverPhoto);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public ActionResult PropertyGallaryPhoto(PropertyGallaryPhoto propertyCoverPhoto, List<HttpPostedFileBase> GallaryPhoto)
        {
            if (GallaryPhoto == null)
            {
                return Json("0");
            }
            var proper = _manageProperty.UpdatePropGallaryPhoto(propertyCoverPhoto, GallaryPhoto);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult DeleteProperty(PropertyDelete propertyDelete)
        {
            var proper = _manageProperty.DeleteProperty(propertyDelete);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult TransferProperty(PropertyTransfer propertTansfer)
        {
            var proper = _manageProperty.UpdateTransferProperty(propertTansfer);
            if (proper)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }

        }

        public ActionResult PartialAddBlack()
        {
            var blackDay = new BlakOutDate();
            blackDay.EndDate = "wd"; blackDay.StartDate = "asd";
            return PartialView("~/Views/Shared/EditorTemplates/BlackOutDate.cshtml", blackDay);
        }

    }
}