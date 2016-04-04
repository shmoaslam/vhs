using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Interface;
using VHS.Services;

namespace VHS.Controllers
{
    [CustomException]
    public class ManageRmController : Controller
    {
        private IAccount _mangeRm;
        // GET: ManageRm
        public ManageRmController(IAccount manageRm)
        {
            _mangeRm = manageRm;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(RegisterViewModel resgisterModel)
        {
            int userType = Convert.ToInt32(UserTypeEnum.RM);
            var result = _mangeRm.RegisterUser(resgisterModel, userType);

            if (result)
            {

                return Json("1");
            }
            else
            {

                return Json("2");
            }
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Arrange()
        {
            return View();
        }
        public ActionResult Block()
        {
            return View();
        }
        public ActionResult Suspend()
        {
            return View();
        }
    }
}