using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Interface;

namespace VHS.Controllers
{
    [Authorize]
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

        [Authorize]
        public void LogOff()
        {
            signout();
        }
    }
}