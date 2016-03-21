using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHS.Controllers
{
    public class ManageBookingController : Controller
    {
        // GET: ManageBooking
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
        public ActionResult Cancelled()
        {
            return View();
        }
    }
}