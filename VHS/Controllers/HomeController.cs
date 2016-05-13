using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Models;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    [CustomException]
    public class HomeController : BaseController
    {
        private IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            var contact = new Contact();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Comingsoon()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Travelogy()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VelvettHolidays()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BookingRequest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingRequest(BookingRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isBookingRequestAddedSuccessfully = _homeService.AddBookingRequest(model);
                if (isBookingRequestAddedSuccessfully)
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Error Taking booking request, Please try again later!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Newsletter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Newsletter(NewsletterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isNewsletterAddedSuccessfully = _homeService.AddNewsletter(model);
                if (isNewsletterAddedSuccessfully)
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Error subcribing Newsletter, Please try again later!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }
    }
}