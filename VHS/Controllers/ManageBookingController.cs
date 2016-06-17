using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Services;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    public class ManageBookingController : BaseController
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
            if (IsRM)
            {
                int rmId = CurrentUser.LoginId;
                var propertList = _manageBooking.GetBookings(rmId);
                return View(propertList);
            }
            else
            {
                var propertList = _manageBooking.GetBookings(0);
                return View(propertList);
            }
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


        public ActionResult Bookings()
        {
            if(IsRM)
            {
                int rmId = CurrentUser.LoginId;
                var propertList = _manageBooking.GetBookings(rmId);
                return View(propertList);
            }
            else
            {
                var propertList = _manageBooking.GetBookings(0);
                return View(propertList);
            }
        }
    }
}