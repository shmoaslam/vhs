using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VHS.Services.App_Code;

namespace VHS.App_Start
{
    public class ActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;
            var session = filterContext.HttpContext.Session;

            if (!(HttpContext.Current.User.Identity.IsAuthenticated))
            {
                if (request.IsAjaxRequest())
                {
                    response.StatusCode = 590;

                }
                else
                {
                    var url = new UrlHelper(filterContext.HttpContext.Request.RequestContext);
                    if (!response.IsRequestBeingRedirected)
                        response.Redirect(url.Action("Login", "Account"));
                }

            }
            else
            {
                int i = CheckPageAccess("OnActionExecuting", filterContext.RouteData);
                if (i == 0)
                {
                    var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
                    var urlHelper = new UrlHelper(context);
                    var url = urlHelper.Action("Denied", "PageAccess");
                    System.Web.HttpContext.Current.Response.Redirect(url);
                }
                base.OnActionExecuting(filterContext);
            }

        }
        private int CheckPageAccess(string methodName, RouteData routeData)
        {
            string controllerName = routeData.Values["controller"].ToString();
            string actionName = routeData.Values["action"].ToString();
            int id = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return 0;
        }
    }
    public class CustomException : HandleErrorAttribute
    {
        string url = ConfigurationManager.AppSettings["URL"].ToString();

        public object MailSend { get; private set; }

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
                var urlHelper = new UrlHelper(context);
                filterContext.Result = new RedirectResult("../PageAccess/Error");
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.Result = new RedirectResult("../PageAccess/Error");
                HttpContext.Current.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
                    var urlHelper = new UrlHelper(context);
                    var url = urlHelper.Action("Error", "PageAccess");
                    System.Web.HttpContext.Current.Response.Redirect(url);
                }
            }

            // Write error logging code here if you wish.

            //if want to get different of the request
            var currentController = (string)filterContext.RouteData.Values["controller"];
            var currentActionName = (string)filterContext.RouteData.Values["action"];
            var ExcMailTo = "smaslam16121985@gmail.com";
            string message = filterContext.Exception.Message;
            //string msg = VHS.Services.App_Code.MailSend.SendGmail(ExcMailTo, "Error Details", message);
            //Write Mail For Alert to Webmaster:-
        }

        //If Error Occured SendMail to Admin:-
    }
}