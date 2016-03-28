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

        [HttpGet]
        public ActionResult EditProperty(int id)
        {
            var propGenralInfo = _manageProperty.GetPropertyDetail(id);
            return View(propGenralInfo);
        }
        [HttpPost]
        public ActionResult EditProperty(PropertyGeneralInfo propGeneralInfo, List<HttpPostedFileBase> Image)
        {
            var proper = _manageProperty.UpdateGeneralInfo(propGeneralInfo, Image);
            return Redirect(Request.UrlReferrer.ToString());
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

    }
}