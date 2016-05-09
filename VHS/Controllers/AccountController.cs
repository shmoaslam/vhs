﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using VHS.Services.Interface;
using VHS.Services;
using VHS.Enum;
using System.Web.Security;
using Facebook;
using VHS.Models;
using VHS.Interface;
using VHS.Services.Models;
using Newtonsoft.Json;

namespace VHS.Controllers
{
    //Mrara
    public class AccountController : BaseController
    {
        private IAccount _login;
        private INotificationService _notificationService;

        public AccountController(IAccount login, INotificationService notificationService)
        {
            _login = login;
            _notificationService = notificationService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpCookie userCookie = Request.Cookies[".USERAUTH"];
                if (userCookie != null && userCookie["User"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    signout();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Login(LoginViewModel loginmodel)
        {
            if (!ModelState.IsValid)
            {
                return Json(loginmodel);
            }
            var result = _login.CheckLogin(loginmodel);
            if (result.LoginId != 0)
            {
                signin(result);
                return Json("1");
            }
            else
            {
                return Json("2");
            }

        }

        //

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Register(RegisterViewModel resgisterModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Mobile");
            if (ModelState.IsValid)
            {
                int userType = Convert.ToInt32(UserTypeEnum.User);
                var result = _login.RegisterUser(resgisterModel, userType);

                if (result)
                {

                    return Json("1");
                }
                else
                {

                    return Json("2");
                }

            }
            else
            {
                return Json("2");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public JsonResult CheckEmailExist(string EmailId)
        {
            try
            {
                if (EmailId != null)
                    return _login.CheckEmailExist(EmailId) ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpCookie userCookie = Request.Cookies[".USERAUTH"];
                if (userCookie != null && userCookie["User"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    signout();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isEmailExist = _login.CheckForgotPasswordEmailExists(model.Email);
                if (!isEmailExist) { ModelState.AddModelError("", "Email does not exists"); return View(model); }
                string code = _login.GeneratePasswordResetToken(model.Email);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { code = code }, protocol: Request.Url.Scheme);
                var body = "Please reset your password by clicking <a href =\"" + callbackUrl + "\">here</a>";
                var subject = "Reset Password";
                _notificationService.SendForgotPasswordEmail(model.Email, subject, body);
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }
            return View(model);
        }


        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (string.IsNullOrEmpty(code)) return View("Error");

            var userEmail = _login.GetUserEmailFromToken(code);

            if (string.IsNullOrEmpty(userEmail)) return View("Error");

            var model = new ResetPasswordViewModel { Email = userEmail };

            return View(model);

        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isEmailExist = _login.CheckForgotPasswordEmailExists(model.Email);
            if (!isEmailExist) { ModelState.AddModelError("", "Invalid request"); return View(model); }
            _login.ResetPassword(model.Email, model.Password);
            return RedirectToAction("ResetPasswordConfirmation", "Account");

        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}

        ////
        //// GET: /Account/SendCode
        //[AllowAnonymous]
        //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        //{
        //    var userId = await SignInManager.GetVerifiedUserIdAsync();
        //    if (userId == null)
        //    {
        //        return View("Error");
        //    }
        //    var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
        //    var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //    return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}



        //
        // GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // Sign in the user with this external login provider if the user already has a login
        //    var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(returnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
        //        case SignInStatus.Failure:
        //        default:
        //            // If the user does not have an account, then prompt the user to create an account
        //            ViewBag.ReturnUrl = returnUrl;
        //            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        //    }
        //}

        //
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            signout();
            return RedirectToAction("Index", "Home");
        }



        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "785642368153482",
                client_secret = "0911326cd881529c423b1df0a45562f0",

                //Test:-
                //client_id = "613786842072494",
                //client_secret = "c9fabdd095042a904cbbb77c8094c47d",

                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email" // Add other permissions as needed
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                //:-Live
                client_id = "785642368153482",
                client_secret = "0911326cd881529c423b1df0a45562f0",

                //Test:-
                //client_id = "613786842072494",
                //client_secret = "c9fabdd095042a904cbbb77c8094c47d",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            // Store the access token in the session for farther use
            Session["AccessToken"] = accessToken;

            // update the facebook client with the access token so 
            // we can make requests on behalf of the user
            fb.AccessToken = accessToken;

            // Get the user's information
            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
            string email = me.email;
            string firstname = me.first_name;
            string middlename = me.middle_name;
            string lastname = me.last_name;


            if (_login.CheckEmailExist(email))
            {
                var registerModel = new RegisterViewModel();
                registerModel.Name = firstname + " " + middlename + " " + lastname;
                registerModel.EmailId = email;
                int userType = Convert.ToInt32(UserTypeEnum.User);
                var register = _login.RegisterUser(registerModel, userType);
                if (register)
                {
                    var uerInfo = _login.GetUserDetail(email);
                    if (uerInfo.Email != null)
                    {
                        signin(uerInfo);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                var uerInfo = _login.GetUserDetail(email);
                signin(uerInfo);
                return RedirectToAction("Index", "Home");
            }
        }

        //AdminDetail Functionality:-
        [AllowAnonymous]
        public ActionResult AdminLogin()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpCookie userCookie = Request.Cookies[".USERAUTH"];
                if (userCookie != null && userCookie["User"] != null)
                {
                    if (CurrentUser.UserType == Convert.ToInt32(UserTypeEnum.Admin))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (CurrentUser.UserType == Convert.ToInt32(UserTypeEnum.RM))
                    {
                        return RedirectToAction("Rm", "Admin");
                    }
                    else
                    {
                        signout();
                        return View();
                    }
                }
                else
                {
                    signout();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult AdminLogin(LoginViewModel loginmodel)
        {
            if (!ModelState.IsValid)
            {
                return Json(loginmodel);
            }

            var userInfo = _login.CheckAdminLogin(loginmodel);
            if (userInfo.Email != null)
            {

                signin(userInfo);
                if (userInfo.UserType == Convert.ToInt32(UserTypeEnum.Admin))
                {
                    return Json("1");
                }
                else if (userInfo.UserType == Convert.ToInt32(UserTypeEnum.RM))
                {
                    return Json("2");
                }
                else
                {
                    return Json("3");
                }

            }
            else
            {
                return Json("0");
            }

        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RMConfirmation(string id)
        {
            var rmconfirmation = _login.RmAccountConfirmation(id);
            return View(rmconfirmation);

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RMConfirmation(RmCreatePassword rmchangePassword)
        {
            var createPassword = _login.RmAccountCreatePassword(rmchangePassword);
            if (createPassword)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                return View();
            }


        }

        private void signin(UserInfo user)
        {
            string name = user.LoginId.ToString();
            FormsAuthentication.SetAuthCookie(name, false);
            string data = JsonConvert.SerializeObject(user);
            SetUserCookie(data);
        }
        //public void writeLoginCookies(string username, bool rememberme)
        //{
        //    //string info = username;
        //    ////FormsAuthentication.SetAuthCookie(info, false);
        //    //HttpCookie userCookie = new HttpCookie(Constants.COOKIE_USERNAME);
        //    //userCookie["UserName"] = HttpUtility.UrlEncode(SecurityHelper.Encrypt(info));
        //    //userCookie["RememberMe"] = HttpUtility.UrlEncode(SecurityHelper.Encrypt(rememberme.ToString()));
        //    //userCookie.Expires = DateTime.Now.AddMonths(1);
        //    //Response.Cookies.Add(userCookie);
        //}



    }
}