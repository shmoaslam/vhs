using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Services;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    public class ManageBookingController : Controller
    {

        private IManageBookingService _manageBooking;
        public ManageBookingController(IManageBookingService manageBooking)
        {
            _manageBooking = manageBooking;
        }

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

        public ActionResult Detail(int id)
        {
            if (id == 0) return View();
            var bookingModel = _manageBooking.GetBookingDetails(id);

            return View(bookingModel);
        }

        [HttpPost]
        public ActionResult UpdateBooking(ManganeBookingViewModel model)
        {
            var status = _manageBooking.UpdateBooking(model);
            return RedirectToAction("Detail", new { Id = model.Id});
        }
    }
}