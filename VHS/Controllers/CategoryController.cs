using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.App_Start;
using VHS.Services.Interface;

namespace VHS.Controllers
{
    [CustomException]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index(int? id)
        {
            if (id == null) return View();

            var properties = _categoryService.GetAllPropertiesByCategory(id);

            return View(properties);
        }
    }
}