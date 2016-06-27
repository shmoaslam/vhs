using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Interface;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    [CustomException]
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
        [HttpGet]
        public ActionResult Waiting()
        {
            var assignProperty = _manageProperty.GetApprovedWaitingProperty();
            return View(assignProperty);
        }
        [HttpGet]
        public ActionResult Delete()
        {
            var assignProperty = _manageProperty.GetDeleteRequestProperty();
            return View( assignProperty);
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
            ViewBag.PropertyId = id;
            return View();
        }
        [HttpGet]
        public ActionResult GetPropertyGeneralInfo(int id)
        {
            var propGenralInfo = _manageProperty.GetPropertyGeneralInfo(id);
            return PartialView("_PropertyGeneralInfo", propGenralInfo);
        }
        [HttpGet]
        public ActionResult GetPropertyAdditionalInfo(int id)
        {
            var propAdditionalInfo = _manageProperty.GetPropertyAdditionalInfo(id);
            return PartialView("_PropertyAdditionalInfo", propAdditionalInfo);
        }
        [HttpGet]
        public ActionResult GetPropertyAmenities(int id)
        {
            var propAmenities = _manageProperty.GetPropertyAmenities(id);
            return PartialView("_PropertyAmenities", propAmenities);
        }
        [HttpGet]
        public ActionResult GetPropertyFixedPrice(int id)
        {
            var propFixedprice = _manageProperty.GetPropertyFixedPrice(id);
            return PartialView("_PropertyFixPricing", propFixedprice);
        }
        [HttpGet]
        public ActionResult GetPropertyVaraiablePrice(int id)
        {
            var propVarablePrice = _manageProperty.GetPropertyVaraiablePrice(id);
            return PartialView("_PropertyVariablePricing", propVarablePrice);
        }
        [HttpGet]
        public ActionResult GetPropertyWeekendPrice(int id)
        {
            var propWEPrice = _manageProperty.GetPropertyWeekendPrice(id);
            return PartialView("_PropertyWeekEndPricing", propWEPrice);
        }

        [HttpGet]
        public ActionResult GetPropertyCoverPhoto(int id)
        {
            var propCoverPhoto = _manageProperty.GetPropertyCoverPhoto(id);
            return PartialView("_PropertyCoverPhoto", propCoverPhoto);
        }
        [HttpGet]
        public ActionResult GetPropertyGallaryPhoto(int id)
        {
            var propGallaryPhoto = _manageProperty.GetPropertyGallaryPhoto(id);
            return PartialView("_PropertyGallaryPhoto", propGallaryPhoto);
        }
        [HttpGet]
        public ActionResult GetRelatedProperty(int id)
        {
            var propGallaryPhoto = _manageProperty.GetRelatedProperty(id);
            return PartialView("_RelatedProperty", propGallaryPhoto);
        }

        [AllowAnonymous]
        public JsonResult GetRelatedPropertyAutocompleteHelp(string query, int regionId)
        {
            List<string> autoCompleteHelp = _manageProperty.GetRelatedPropertyAutocompleteHelp(query,regionId);

            return Json(autoCompleteHelp);
        }
        [HttpGet]
        public ActionResult GetPropertyTravleAmbassador(int id)
        {
            // var propGallaryPhoto = _manageProperty.GetPropertyDetail(id);
            return PartialView("_PropertyTravelAmbassador");
        }
        [HttpGet]
        public ActionResult GetPropertyTransfer(int id)
        {
            var propTransfer = _manageProperty.GetPropertyTransfer(id);
            return PartialView("_PropertyTransfer", propTransfer);
        }
        [HttpGet]
        public ActionResult GetPropertyDelete(int id)
        {
            var propDelete = _manageProperty.GetPropertyDelete(id);
            return PartialView("_PropertyDelete", propDelete);
        }
        [HttpGet]
        public ActionResult GetPropertyApproval(int id)
        {
            var propDelete = _manageProperty.GetPropertyApproval(id);
            return PartialView("_PropertyApproval", propDelete);
        }
        
        [HttpGet]
        public ActionResult GetPropertyDeleteRequest(int id)
        {
            var propNotity = _manageProperty.GetPropertyDelete(id);
            return PartialView("_PropertyDeleteRequest", propNotity);
        }
        [HttpGet]
        public ActionResult GetPropertyAprrovalRequest(int id)
        {
            var propNotity = _manageProperty.GetPropertyDelete(id);
            return PartialView("_PropertyAprrovalRequest", propNotity);
        }
        [HttpPost]
        public ActionResult ApprovedProperty(PropertyNotification notification)
        {
            var proper = _manageProperty.ApprovedProperty(notification);
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
        public ActionResult PropertyAprrovalRequest(PropertyNotification notification)
        {
            var proper = _manageProperty.PropertyAprrovalRequest(notification);
            if (proper)
                return Json("1");
            else
                return Json("0");
        }
        [HttpPost]
        public ActionResult PropertyDeleteRequest(PropertyNotification notification)
        {
            var proper = _manageProperty.PropertyDeleteRequest(notification);
            if (proper)
                return Json("1");
            else
                return Json("0");
        }
        [HttpPost]
        public JsonResult PropertyGeneralInfo(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> Image)
        {
            if (Image == null)
            {
                return Json("0");
            }
            var proper = _manageProperty.UpdateGeneralInfo(propGeneralInfo, Image);
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
        public JsonResult PropertyWeekendPricing(PropertyWeekendPricing propWePrice)
        {
            var proper = _manageProperty.UpdatePropWeekEndPrice(propWePrice);
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
        public JsonResult PropertyCoverPhoto(PropertyCoverPhoto propertyCoverPhoto, List<HttpPostedFileBase> CoverPhoto)
        {
            if (CoverPhoto == null)
            {
                return Json("0");
            }
            var proper = _manageProperty.UpdatePropCoverPhoto(propertyCoverPhoto, CoverPhoto);
            if (proper)
            {
                var imageList = _manageProperty.GetPropertyCoverPhoto(propertyCoverPhoto.PropertyId);
                return Json(imageList.imageCoverPhoto, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public JsonResult PropertyGallaryPhoto(PropertyGallaryPhoto propertyCoverPhoto, List<HttpPostedFileBase> GallaryPhoto)
        {
            if (GallaryPhoto == null)
            {
                return Json("0");
            }
            var proper = _manageProperty.UpdatePropGallaryPhoto(propertyCoverPhoto, GallaryPhoto);
            if (proper)
            {
                var imageList = _manageProperty.GetPropertyGallaryPhoto(propertyCoverPhoto.PropertyId);
                return Json(imageList.imageGalaryPhoto, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]
        public JsonResult UpdateRelatedProperty(RelatedProperty model)
        {
            if (model == null)
            {
                return Json("0");
            }
            var proper = _manageProperty.UpdateRelatedProperty(model);
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
        public JsonResult DeleteProperty(PropertyNotification propertyDelete)
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

        [HttpGet]
        public ActionResult AddProperty()
        {
            return View();
        }

    }
}