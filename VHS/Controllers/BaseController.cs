using Microsoft.Owin.Security.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VHS.Common;
using VHS.Services;

namespace VHS.Controllers
{
    public class BaseController : Controller
    {
        private UserInfo _currentUser = null;

        public void SetUserCookie(string value)
        {
            HttpCookie userCookie = new HttpCookie(Constants.COOKIE_USER);
            userCookie["User"] = value;
            userCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(userCookie);
        }

        public UserInfo CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    if (Request.Cookies[Constants.COOKIE_USER] != null)
                    {
                        HttpCookie userCookie = Request.Cookies[Constants.COOKIE_USER];
                        string userdata = userCookie["User"];
                        _currentUser = JsonConvert.DeserializeObject<UserInfo>(userdata);
                    }
                }
                return _currentUser;
            }
        }

        public bool IsAdmin
        {
            get
            {
                bool isAdmin = false;
                if (CurrentUser != null)
                {

                    if (Convert.ToInt32(CurrentUser.UserType) == Convert.ToInt32(UserTypeEnum.Admin))
                    {
                        isAdmin = true;
                    }

                }

                return isAdmin;
            }
        }
        public bool IsRM
        {
            get
            {
                bool isRM = false;
                if (CurrentUser != null)
                {

                    if (Convert.ToInt32(CurrentUser.UserType) == Convert.ToInt32(UserTypeEnum.RM))
                    {
                        isRM = true;
                    }

                }

                return isRM;
            }
        }

        protected void signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cookies.Clear();

            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2 = new HttpCookie(Constants.COOKIE_USER, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}