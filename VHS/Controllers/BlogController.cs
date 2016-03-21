using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VHS.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SinglePost()
        {
            return View();
        }
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult Alternative()
        {
            return View();
        }
    }
}