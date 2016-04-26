using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Interface;

namespace VHS.Controllers
{
    [Authorize]
    //[CustomException]
    public class AdminController : BaseController
    {
        private IAdminHome _adminHome;
        public AdminController(IAdminHome adminHome)
        {
            _adminHome = adminHome;
        }
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            if (IsAdmin)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }
      

        [HttpGet]
        public ActionResult GetApprovedProperty()
        {
            if (IsAdmin)
            {
                var assignedProperties = _adminHome.GetAddedProperty();
                return PartialView("_ApprovedProperty", assignedProperties);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }
        [HttpGet]
        public ActionResult GetBookedProperty()
        {
            if (IsAdmin)
            {
                return PartialView("_BookedProperty");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Account");
            }

        }


        public ActionResult Rm()
        {
            if (IsRM)
            {

                var assignedProperties = _adminHome.GetAssignedPropertyRm(CurrentUser.LoginId);
                return View(assignedProperties);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Account");
            }
        }
        public ActionResult Property()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            signout();
            return RedirectToAction("Index", "Home");
        }
    }
}