using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Interface;
using VHS.Services.Interface;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    [Authorize]
    [CustomException]
    public class ProfileController : Controller
    {
        private IProfile _profile;
        public ProfileController(IProfile profile)
        {
            _profile = profile;
        }
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            int userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var profile = _profile.GetUserDetail(userId);
            return View(profile);
        }
        [HttpPost]
        public ActionResult UpdateProfile(ProfileViewModel profilevm, FormCollection frm)
        {
            int userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var profile = _profile.UpdateProfile(profilevm, userId);
            if (profile)
            {
                TempData["ErrorMessage"] = "Profile updated sucessfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error occured during profile updated .";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateProfileAdditionalInfo(ProfileViewModel profilevm, List<HttpPostedFileBase> Document)
        {
            int userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var profile = _profile.UpdateProfileAdditionalInfo(profilevm, userId, Document);
            if (profile)
            {
                TempData["ErrorMessageAdditional"] = "Profile updated sucessfully.";
            }
            else
            {
                TempData["ErrorMessageAdditional"] = "Error occured during profile updated .";
            }
            return RedirectToAction("Index");
        }
       
    }
}